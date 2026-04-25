import { useState } from "react";
import { Plus, Truck, Calendar, Pencil } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Badge } from "@/components/ui/badge";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { useToast } from "@/hooks/use-toast";
import { DeliveriesApi, ProjectsApi, type AddDeliveryDto, type Delivery } from "@/lib/api";
import { useResource } from "@/hooks/useResource";
import { PageHeader } from "@/components/PageHeader";
import { ConfirmDelete } from "@/components/ConfirmDelete";
import { EmptyState, ErrorState, LoadingState } from "@/components/EmptyState";

const STATUS = ["Pendiente", "Entregado"];
const today = new Date().toISOString().slice(0, 10);
const empty: AddDeliveryDto = { deliveryDate: `${today}T00:00:00`, statusDelivery: "Pendiente", projectId: 0 };

export default function Deliveries() {
  const { data, loading, error, reload } = useResource(DeliveriesApi.list);
  const { data: projects } = useResource(ProjectsApi.list);
  const { toast } = useToast();
  const [open, setOpen] = useState(false);
  const [dateInput, setDateInput] = useState(today);
  const [form, setForm] = useState<AddDeliveryDto>(empty);
  const [editId, setEditId] = useState<number | null>(null);
  const [submitting, setSubmitting] = useState(false);

  function openCreate() {
    setEditId(null);
    setForm(empty);
    setDateInput(today);
    setOpen(true);
  }

  function openEdit(d: Delivery) {
    setEditId(d.id);
    setForm({ deliveryDate: d.deliveryDate, statusDelivery: d.statusDelivery, projectId: d.projectId });
    const iso = (d.deliveryDate || "").slice(0, 10);
    setDateInput(iso || today);
    setOpen(true);
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    if (!form.projectId) { toast({ title: "Selecciona un proyecto", variant: "destructive" }); return; }
    setSubmitting(true);
    try {
      const payload = { ...form, deliveryDate: `${dateInput}T00:00:00` };
      if (editId != null) {
        await DeliveriesApi.update(editId, payload);
        toast({ title: "Actualizado correctamente ✅" });
      } else {
        await DeliveriesApi.create(payload);
        toast({ title: "Entrega programada" });
      }
      setForm(empty); setEditId(null); setDateInput(today); setOpen(false); reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    } finally { setSubmitting(false); }
  }

  async function remove(id: number) {
    try {
      await DeliveriesApi.remove(id);
      toast({ title: "Entrega eliminada" });
      reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    }
  }

  function projectName(id: number) {
    const p = projects.find((x) => x.id === id);
    return p ? p.nameProyect : `Proyecto #${id}`;
  }

  return (
    <div className="max-w-7xl mx-auto">
      <PageHeader
        icon={<Truck className="h-6 w-6" />}
        title="Entregas"
        description="Programa y rastrea las entregas de cada proyecto terminado."
        action={
          <Button onClick={openCreate} className="bg-gradient-amber text-wood-dark hover:opacity-90 shadow-warm font-semibold">
            <Plus className="h-4 w-4 mr-2" /> Nueva entrega
          </Button>
        }
      />

      <Dialog open={open} onOpenChange={(o) => { setOpen(o); if (!o) { setEditId(null); setForm(empty); setDateInput(today); } }}>
        <DialogContent className="max-w-lg">
          <DialogHeader><DialogTitle className="font-display text-2xl">{editId != null ? "Editar entrega" : "Nueva entrega"}</DialogTitle></DialogHeader>
          <form onSubmit={submit} className="space-y-4">
            <div className="space-y-2">
              <Label>Proyecto</Label>
              <Select value={form.projectId ? String(form.projectId) : ""} onValueChange={(v) => setForm({ ...form, projectId: parseInt(v) })}>
                <SelectTrigger><SelectValue placeholder="Selecciona un proyecto" /></SelectTrigger>
                <SelectContent>
                  {projects.length === 0 && <div className="px-3 py-2 text-sm text-muted-foreground">Crea un proyecto primero</div>}
                  {projects.map((p) => <SelectItem key={p.id} value={String(p.id)}>{p.nameProyect}</SelectItem>)}
                </SelectContent>
              </Select>
            </div>
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-2">
                <Label>Fecha de entrega</Label>
                <Input type="date" required value={dateInput} onChange={(e) => setDateInput(e.target.value)} />
              </div>
              <div className="space-y-2">
                <Label>Estado</Label>
                <Select value={form.statusDelivery} onValueChange={(v) => setForm({ ...form, statusDelivery: v as any })}>
                  <SelectTrigger><SelectValue /></SelectTrigger>
                  <SelectContent>
                    {STATUS.map((s) => <SelectItem key={s} value={s}>{s}</SelectItem>)}
                  </SelectContent>
                </Select>
              </div>
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
          {!loading && !error && data.length === 0 && <EmptyState message="No hay entregas programadas" icon={<Truck className="h-6 w-6" />} />}
          {!loading && !error && data.length > 0 && (
            <Table>
              <TableHeader>
                <TableRow className="bg-muted/50">
                  <TableHead>Proyecto</TableHead>
                  <TableHead>Fecha</TableHead>
                  <TableHead>Estado</TableHead>
                  <TableHead className="text-right w-32">Acciones</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {data.map((d) => {
                  const date = new Date(d.deliveryDate);
                  const isDelivered = (d.statusDelivery || "").toLowerCase() === "entregado";
                  return (
                    <TableRow key={d.id}>
                      <TableCell>
                        <div className="font-medium">{projectName(d.projectId)}</div>
                        <div className="text-xs text-muted-foreground">ID #{d.id}</div>
                      </TableCell>
                      <TableCell>
                        <div className="flex items-center gap-1.5 text-sm">
                          <Calendar className="h-3.5 w-3.5 text-amber" />
                          {isNaN(date.getTime()) ? d.deliveryDate : date.toLocaleDateString("es", { day: "2-digit", month: "short", year: "numeric" })}
                        </div>
                      </TableCell>
                      <TableCell>
                        <Badge variant="outline" className={isDelivered
                          ? "bg-emerald-100 text-emerald-800 border-emerald-200"
                          : "bg-amber/20 text-wood-dark border-amber/40"}>
                          {d.statusDelivery}
                        </Badge>
                      </TableCell>
                      <TableCell className="text-right">
                        <div className="flex justify-end gap-1">
                          <Button variant="ghost" size="icon" onClick={() => openEdit(d)} className="text-amber hover:bg-amber/10 hover:text-wood-dark">
                            <Pencil className="h-4 w-4" />
                          </Button>
                          <ConfirmDelete itemLabel={`la entrega #${d.id}`} onConfirm={() => remove(d.id)} />
                        </div>
                      </TableCell>
                    </TableRow>
                  );
                })}
              </TableBody>
            </Table>
          )}
        </CardContent>
      </Card>
    </div>
  );
}
