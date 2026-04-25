import { useState } from "react";
import { Plus, Package, Pencil } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { useToast } from "@/hooks/use-toast";
import { MaterialsApi, type AddMaterialDto, type Material } from "@/lib/api";
import { useResource } from "@/hooks/useResource";
import { PageHeader } from "@/components/PageHeader";
import { ConfirmDelete } from "@/components/ConfirmDelete";
import { EmptyState, ErrorState, LoadingState } from "@/components/EmptyState";

const empty: AddMaterialDto = { nombreMaterial: "", cantidad: 0, precioUnitario: 0, imageMaterial: "" };

export default function Materials() {
  const { data, loading, error, reload } = useResource(MaterialsApi.list);
  const { toast } = useToast();
  const [open, setOpen] = useState(false);
  const [form, setForm] = useState<AddMaterialDto>(empty);
  const [editId, setEditId] = useState<number | null>(null);
  const [submitting, setSubmitting] = useState(false);

  function openCreate() { setEditId(null); setForm(empty); setOpen(true); }
  function openEdit(m: Material) {
    setEditId(m.id);
    setForm({ nombreMaterial: m.nombreMaterial, cantidad: m.cantidad, precioUnitario: m.precioUnitario, imageMaterial: m.imageMaterial });
    setOpen(true);
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    if (form.cantidad < 0 || form.precioUnitario < 0) {
      toast({ title: "Valores numéricos inválidos", variant: "destructive" });
      return;
    }
    setSubmitting(true);
    try {
      if (editId != null) {
        await MaterialsApi.update(editId, form);
        toast({ title: "Actualizado correctamente ✅", description: form.nombreMaterial });
      } else {
        await MaterialsApi.create(form);
        toast({ title: "Material agregado", description: form.nombreMaterial });
      }
      setForm(empty); setEditId(null); setOpen(false); reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    } finally { setSubmitting(false); }
  }

  async function remove(id: number) {
    try {
      await MaterialsApi.remove(id);
      toast({ title: "Material eliminado" });
      reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    }
  }

  return (
    <div className="max-w-7xl mx-auto">
      <PageHeader
        icon={<Package className="h-6 w-6" />}
        title="Materiales"
        description="Inventario de maderas, herrajes y suministros del taller."
        action={
          <Button onClick={openCreate} className="bg-gradient-amber text-wood-dark hover:opacity-90 shadow-warm font-semibold">
            <Plus className="h-4 w-4 mr-2" /> Nuevo material
          </Button>
        }
      />

      <Dialog open={open} onOpenChange={(o) => { setOpen(o); if (!o) { setEditId(null); setForm(empty); } }}>
        <DialogContent className="max-w-lg">
          <DialogHeader><DialogTitle className="font-display text-2xl">{editId != null ? "Editar material" : "Nuevo material"}</DialogTitle></DialogHeader>
          <form onSubmit={submit} className="space-y-4">
            <div className="space-y-2">
              <Label>Nombre del material</Label>
              <Input required value={form.nombreMaterial} onChange={(e) => setForm({ ...form, nombreMaterial: e.target.value })} />
            </div>
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-2">
                <Label>Cantidad</Label>
                <Input type="number" min="0" required value={form.cantidad}
                  onChange={(e) => setForm({ ...form, cantidad: parseInt(e.target.value) || 0 })} />
              </div>
              <div className="space-y-2">
                <Label>Precio unitario ($)</Label>
                <Input type="number" min="0" step="0.01" required value={form.precioUnitario}
                  onChange={(e) => setForm({ ...form, precioUnitario: parseFloat(e.target.value) || 0 })} />
              </div>
            </div>
            <div className="space-y-2">
              <Label>URL de la imagen</Label>
              <Input placeholder="https://..." value={form.imageMaterial} onChange={(e) => setForm({ ...form, imageMaterial: e.target.value })} />
              {form.imageMaterial && (
                <div className="rounded-md overflow-hidden border border-border bg-muted aspect-video">
                  <img src={form.imageMaterial} alt="preview" className="w-full h-full object-cover" onError={(e) => (e.currentTarget.style.display = "none")} />
                </div>
              )}
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
        <Card className="border-border"><CardContent><EmptyState message="No hay materiales en inventario" icon={<Package className="h-6 w-6" />} /></CardContent></Card>
      )}

      {!loading && !error && data.length > 0 && (
        <div className="grid gap-5 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
          {data.map((m, i) => (
            <Card key={`${m.id ?? "x"}-${i}`} className="border-border shadow-soft hover:shadow-warm transition-all overflow-hidden group">
              <div className="aspect-square bg-gradient-to-br from-muted to-secondary relative overflow-hidden">
                {m.imageMaterial ? (
                  <img src={m.imageMaterial} alt={m.nombreMaterial}
                    className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-500"
                    onError={(e) => { e.currentTarget.style.display = "none"; }} />
                ) : (
                  <div className="w-full h-full flex items-center justify-center text-muted-foreground">
                    <Package className="h-12 w-12" />
                  </div>
                )}
                <div className="absolute top-2 right-2 flex gap-1">
                  <Button size="icon" variant="secondary" className="h-8 w-8 shadow-warm" onClick={() => openEdit(m)}>
                    <Pencil className="h-3.5 w-3.5" />
                  </Button>
                  <ConfirmDelete itemLabel={m.nombreMaterial} onConfirm={() => remove(m.id)}
                    trigger={
                      <Button size="icon" variant="secondary" className="h-8 w-8 shadow-warm">
                        <span className="sr-only">Eliminar</span>
                        <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2"><path d="M3 6h18M8 6V4a2 2 0 012-2h4a2 2 0 012 2v2m3 0v14a2 2 0 01-2 2H7a2 2 0 01-2-2V6h14z" /></svg>
                      </Button>
                    } />
                </div>
              </div>
              <CardContent className="pt-4">
                <div className="font-display font-semibold text-lg leading-tight">{m.nombreMaterial}</div>
                <div className="flex items-baseline justify-between mt-2">
                  <div className="text-sm text-muted-foreground">Stock: <span className="font-medium text-foreground">{m.cantidad}</span></div>
                  <div className="font-mono font-bold text-amber">${m.precioUnitario.toLocaleString()}</div>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>
      )}
    </div>
  );
}
