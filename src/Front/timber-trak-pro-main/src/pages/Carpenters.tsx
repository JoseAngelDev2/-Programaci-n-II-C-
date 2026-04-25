import { useState } from "react";
import { Plus, Hammer, Phone, Pencil } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Table, TableBody, TableCell, TableRow } from "@/components/ui/table";
import { Badge } from "@/components/ui/badge";
import { useToast } from "@/hooks/use-toast";
import { CarpintersApi, type AddCarpinterDto, type Carpinter } from "@/lib/api";
import { useResource } from "@/hooks/useResource";
import { PageHeader } from "@/components/PageHeader";
import { ConfirmDelete } from "@/components/ConfirmDelete";
import { EmptyState, ErrorState, LoadingState } from "@/components/EmptyState";

const empty: AddCarpinterDto = { name: "", specialty: "", phone: "", salary: 0 };

export default function Carpenters() {
  const { data, loading, error, reload } = useResource(CarpintersApi.list);
  const { toast } = useToast();
  const [open, setOpen] = useState(false);
  const [form, setForm] = useState<AddCarpinterDto>(empty);
  const [editId, setEditId] = useState<number | null>(null);
  const [submitting, setSubmitting] = useState(false);

  function openCreate() { setEditId(null); setForm(empty); setOpen(true); }
  function openEdit(c: Carpinter) {
    setEditId(c.id);
    setForm({ name: c.name, specialty: c.specialty, phone: c.phone, salary: c.salary });
    setOpen(true);
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    if (form.salary < 0) { toast({ title: "Salario inválido", variant: "destructive" }); return; }
    setSubmitting(true);
    try {
      if (editId != null) {
        await CarpintersApi.update(editId, form);
        toast({ title: "Actualizado correctamente ✅", description: form.name });
      } else {
        await CarpintersApi.create(form);
        toast({ title: "Carpintero registrado", description: form.name });
      }
      setForm(empty); setEditId(null); setOpen(false); reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    } finally { setSubmitting(false); }
  }

  async function remove(id: number) {
    try {
      await CarpintersApi.remove(id);
      toast({ title: "Carpintero eliminado" });
      reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    }
  }

  return (
    <div className="max-w-7xl mx-auto">
      <PageHeader
        icon={<Hammer className="h-6 w-6" />}
        title="Carpinteros"
        description="El equipo de artesanos que da vida a cada proyecto."
        action={
          <Button onClick={openCreate} className="bg-gradient-amber text-wood-dark hover:opacity-90 shadow-warm font-semibold">
            <Plus className="h-4 w-4 mr-2" /> Nuevo carpintero
          </Button>
        }
      />

      <Dialog open={open} onOpenChange={(o) => { setOpen(o); if (!o) { setEditId(null); setForm(empty); } }}>
        <DialogContent className="max-w-lg">
          <DialogHeader><DialogTitle className="font-display text-2xl">{editId != null ? "Editar carpintero" : "Nuevo carpintero"}</DialogTitle></DialogHeader>
          <form onSubmit={submit} className="space-y-4">
            <div className="space-y-2">
              <Label>Nombre completo</Label>
              <Input required value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} />
            </div>
            <div className="space-y-2">
              <Label>Especialidad</Label>
              <Input required placeholder="Ej. Ebanistería, Tallado..." value={form.specialty} onChange={(e) => setForm({ ...form, specialty: e.target.value })} />
            </div>
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-2">
                <Label>Teléfono</Label>
                <Input required value={form.phone} onChange={(e) => setForm({ ...form, phone: e.target.value })} />
              </div>
              <div className="space-y-2">
                <Label>Salario ($)</Label>
                <Input type="number" min="0" step="0.01" required value={form.salary}
                  onChange={(e) => setForm({ ...form, salary: parseFloat(e.target.value) || 0 })} />
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

      {loading && <LoadingState />}
      {error && !loading && <ErrorState message={error} />}
      {!loading && !error && data.length === 0 && (
        <Card className="border-border"><CardContent><EmptyState message="No hay carpinteros registrados" icon={<Hammer className="h-6 w-6" />} /></CardContent></Card>
      )}

      {!loading && !error && data.length > 0 && (
        <div className="grid gap-4 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3">
          {data.map((c, i) => (
            <Card key={`${c.id ?? "x"}-${i}`} className="border-border shadow-soft hover:shadow-warm transition-all hover:-translate-y-0.5">
              <CardContent className="pt-6">
                <div className="flex items-start justify-between gap-2 mb-3">
                  <div className="flex items-center gap-3">
                    <div className="h-12 w-12 rounded-full bg-gradient-wood text-amber flex items-center justify-center font-display text-lg font-bold">
                      {c.name.charAt(0).toUpperCase()}
                    </div>
                    <div>
                      <div className="font-display font-semibold text-lg leading-tight">{c.name}</div>
                      <Badge variant="outline" className="mt-1 bg-amber/10 border-amber/30 text-wood-dark text-xs">{c.specialty}</Badge>
                    </div>
                  </div>
                  <div className="flex gap-1">
                    <Button variant="ghost" size="icon" onClick={() => openEdit(c)} className="text-amber hover:bg-amber/10 hover:text-wood-dark h-8 w-8">
                      <Pencil className="h-4 w-4" />
                    </Button>
                    <ConfirmDelete itemLabel={c.name} onConfirm={() => remove(c.id)} />
                  </div>
                </div>
                <Table>
                  <TableBody>
                    <TableRow className="border-0">
                      <TableCell className="px-0 py-1 text-xs text-muted-foreground"><Phone className="h-3 w-3 inline mr-1" /> Teléfono</TableCell>
                      <TableCell className="px-0 py-1 text-sm text-right">{c.phone}</TableCell>
                    </TableRow>
                    <TableRow className="border-0">
                      <TableCell className="px-0 py-1 text-xs text-muted-foreground">Salario</TableCell>
                      <TableCell className="px-0 py-1 text-sm text-right font-mono font-medium text-foreground">${c.salary.toLocaleString()}</TableCell>
                    </TableRow>
                  </TableBody>
                </Table>
              </CardContent>
            </Card>
          ))}
        </div>
      )}
    </div>
  );
}
