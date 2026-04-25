import { useState } from "react";
import { Plus, Briefcase, Pencil } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Badge } from "@/components/ui/badge";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { useToast } from "@/hooks/use-toast";
import { ProjectsApi, ClientsApi, type AddProjectDto, type Project } from "@/lib/api";
import { useResource } from "@/hooks/useResource";
import { PageHeader } from "@/components/PageHeader";
import { ConfirmDelete } from "@/components/ConfirmDelete";
import { EmptyState, ErrorState, LoadingState } from "@/components/EmptyState";

const STATUSES = ["En progreso", "Completado", "Pendiente"];
const empty: AddProjectDto = { nameProyect: "", description: "", status: "Pendiente", total: 0, clienteId: 0 };

function statusVariant(s: string) {
  const k = s.toLowerCase();
  if (k === "completado") return "bg-emerald-100 text-emerald-800 border-emerald-200";
  if (k === "en progreso") return "bg-amber/20 text-wood-dark border-amber/30";
  return "bg-muted text-muted-foreground border-border";
}

export default function Projects() {
  const { data, loading, error, reload } = useResource(ProjectsApi.list);
  const { data: clients } = useResource(ClientsApi.list);
  const { toast } = useToast();
  const [open, setOpen] = useState(false);
  const [form, setForm] = useState<AddProjectDto>(empty);
  const [editId, setEditId] = useState<number | null>(null);
  const [submitting, setSubmitting] = useState(false);

  function openCreate() { setEditId(null); setForm(empty); setOpen(true); }
  function openEdit(p: Project) {
    setEditId(p.id);
    setForm({ nameProyect: p.nameProyect, description: p.description, status: p.status, total: p.total, clienteId: p.clienteId });
    setOpen(true);
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    if (!form.clienteId) { toast({ title: "Selecciona un cliente", variant: "destructive" }); return; }
    if (form.total < 0) { toast({ title: "Total inválido", variant: "destructive" }); return; }
    setSubmitting(true);
    try {
      if (editId != null) {
        await ProjectsApi.update(editId, form);
        toast({ title: "Actualizado correctamente ✅", description: form.nameProyect });
      } else {
        await ProjectsApi.create(form);
        toast({ title: "Proyecto creado", description: form.nameProyect });
      }
      setForm(empty); setEditId(null); setOpen(false); reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    } finally { setSubmitting(false); }
  }

  async function remove(id: number) {
    try {
      await ProjectsApi.remove(id);
      toast({ title: "Proyecto eliminado" });
      reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    }
  }

  function clientName(id: number) {
    const c = clients.find((x) => x.id === id);
    return c ? `${c.name} ${c.lastname}` : `Cliente #${id}`;
  }

  return (
    <div className="max-w-7xl mx-auto">
      <PageHeader
        icon={<Briefcase className="h-6 w-6" />}
        title="Proyectos"
        description="Lleva el control de cada encargo: estado, cliente y monto facturado."
        action={
          <Button onClick={openCreate} className="bg-gradient-amber text-wood-dark hover:opacity-90 shadow-warm font-semibold">
            <Plus className="h-4 w-4 mr-2" /> Nuevo proyecto
          </Button>
        }
      />

      <Dialog open={open} onOpenChange={(o) => { setOpen(o); if (!o) { setEditId(null); setForm(empty); } }}>
        <DialogContent className="max-w-lg">
          <DialogHeader><DialogTitle className="font-display text-2xl">{editId != null ? "Editar proyecto" : "Nuevo proyecto"}</DialogTitle></DialogHeader>
          <form onSubmit={submit} className="space-y-4">
            <div className="space-y-2">
              <Label>Nombre del proyecto</Label>
              <Input required value={form.nameProyect} onChange={(e) => setForm({ ...form, nameProyect: e.target.value })} />
            </div>
            <div className="space-y-2">
              <Label>Descripción</Label>
              <Textarea required value={form.description} onChange={(e) => setForm({ ...form, description: e.target.value })} />
            </div>
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-2">
                <Label>Estado</Label>
                <Select value={form.status} onValueChange={(v) => setForm({ ...form, status: v })}>
                  <SelectTrigger><SelectValue /></SelectTrigger>
                  <SelectContent>
                    {STATUSES.map((s) => <SelectItem key={s} value={s}>{s}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-2">
                <Label>Total ($)</Label>
                <Input type="number" min="0" step="0.01" required value={form.total}
                  onChange={(e) => setForm({ ...form, total: parseFloat(e.target.value) || 0 })} />
              </div>
            </div>
            <div className="space-y-2">
              <Label>Cliente</Label>
              <Select value={form.clienteId ? String(form.clienteId) : ""} onValueChange={(v) => setForm({ ...form, clienteId: parseInt(v) })}>
                <SelectTrigger><SelectValue placeholder="Selecciona un cliente" /></SelectTrigger>
                <SelectContent>
                  {clients.length === 0 && <div className="px-3 py-2 text-sm text-muted-foreground">Crea un cliente primero</div>}
                  {clients.map((c) => <SelectItem key={c.id} value={String(c.id)}>{c.name} {c.lastname}</SelectItem>)}
                </SelectContent>
              </Select>
            </div>
            <DialogFooter>
              <Button type="button" variant="outline" onClick={() => setOpen(false)}>Cancelar</Button>
              <Button type="submit" disabled={submitting} className="bg-primary text-primary-foreground">
                {submitting ? "Guardando..." : editId != null ? "Actualizar" : "Guardar"}
              </Button>
            </DialogFooter>
          </form>
        </DialogContent>
      </Dialog>

      <Card className="border-border shadow-soft">
        <CardContent className="p-0">
          {loading && <LoadingState />}
          {error && !loading && <div className="p-6"><ErrorState message={error} /></div>}
          {!loading && !error && data.length === 0 && <EmptyState message="No hay proyectos" icon={<Briefcase className="h-6 w-6" />} />}
          {!loading && !error && data.length > 0 && (
            <Table>
              <TableHeader>
                <TableRow className="bg-muted/50">
                  <TableHead>Proyecto</TableHead>
                  <TableHead className="hidden md:table-cell">Cliente</TableHead>
                  <TableHead>Estado</TableHead>
                  <TableHead className="text-right">Total</TableHead>
                  <TableHead className="text-right w-32">Acciones</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {data.map((p) => (
                  <TableRow key={p.id}>
                    <TableCell>
                      <div className="font-medium">{p.nameProyect}</div>
                      <div className="text-xs text-muted-foreground line-clamp-1 max-w-xs">{p.description}</div>
                    </TableCell>
                    <TableCell className="hidden md:table-cell text-sm text-muted-foreground">{clientName(p.clienteId)}</TableCell>
                    <TableCell>
                      <Badge variant="outline" className={statusVariant(p.status)}>{p.status}</Badge>
                    </TableCell>
                    <TableCell className="text-right font-mono font-medium">${p.total.toLocaleString()}</TableCell>
                    <TableCell className="text-right">
                      <div className="flex justify-end gap-1">
                        <Button variant="ghost" size="icon" onClick={() => openEdit(p)} className="text-amber hover:bg-amber/10 hover:text-wood-dark">
                          <Pencil className="h-4 w-4" />
                        </Button>
                        <ConfirmDelete itemLabel={p.nameProyect} onConfirm={() => remove(p.id)} />
                      </div>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          )}
        </CardContent>
      </Card>
    </div>
  );
}
