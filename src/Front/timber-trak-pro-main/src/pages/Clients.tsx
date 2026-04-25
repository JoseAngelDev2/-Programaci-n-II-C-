import { useState } from "react";
import { Plus, Users, Mail, Phone, MapPin, Pencil } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Dialog, DialogContent, DialogFooter, DialogHeader, DialogTitle, DialogTrigger } from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { useToast } from "@/hooks/use-toast";
import { ClientsApi, type AddClientDto, type Client } from "@/lib/api";
import { useResource } from "@/hooks/useResource";
import { PageHeader } from "@/components/PageHeader";
import { ConfirmDelete } from "@/components/ConfirmDelete";
import { EmptyState, ErrorState, LoadingState } from "@/components/EmptyState";

const empty: AddClientDto = { name: "", lastname: "", address: "", phone: "", email: "" };

export default function Clients() {
  const { data, loading, error, reload } = useResource(ClientsApi.list);
  const { toast } = useToast();
  const [open, setOpen] = useState(false);
  const [form, setForm] = useState<AddClientDto>(empty);
  const [editId, setEditId] = useState<number | null>(null);
  const [submitting, setSubmitting] = useState(false);

  function openCreate() {
    setEditId(null);
    setForm(empty);
    setOpen(true);
  }

  function openEdit(c: Client) {
    setEditId(c.id);
    setForm({ name: c.name, lastname: c.lastname, address: c.address, phone: c.phone, email: c.email });
    setOpen(true);
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(form.email)) {
      toast({ title: "Email inválido", variant: "destructive" });
      return;
    }
    setSubmitting(true);
    try {
      if (editId != null) {
        await ClientsApi.update(editId, form);
        toast({ title: "Actualizado correctamente ✅", description: `${form.name} ${form.lastname}` });
      } else {
        await ClientsApi.create(form);
        toast({ title: "Cliente creado", description: `${form.name} ${form.lastname}` });
      }
      setForm(empty);
      setEditId(null);
      setOpen(false);
      reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    } finally {
      setSubmitting(false);
    }
  }

  async function remove(id: number) {
    try {
      await ClientsApi.remove(id);
      toast({ title: "Cliente eliminado" });
      reload();
    } catch (err) {
      toast({ title: "Error", description: err instanceof Error ? err.message : "", variant: "destructive" });
    }
  }

  return (
    <div className="max-w-7xl mx-auto">
      <PageHeader
        icon={<Users className="h-6 w-6" />}
        title="Clientes"
        description="Administra tu cartera de clientes y mantén su información de contacto al día."
        action={
          <Button onClick={openCreate} className="bg-gradient-amber text-wood-dark hover:opacity-90 shadow-warm font-semibold">
            <Plus className="h-4 w-4 mr-2" /> Nuevo cliente
          </Button>
        }
      />

      <Dialog open={open} onOpenChange={(o) => { setOpen(o); if (!o) { setEditId(null); setForm(empty); } }}>
        <DialogContent className="max-w-lg">
          <DialogHeader>
            <DialogTitle className="font-display text-2xl">{editId != null ? "Editar cliente" : "Nuevo cliente"}</DialogTitle>
          </DialogHeader>
          <form onSubmit={submit} className="space-y-4">
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-2">
                <Label>Nombre</Label>
                <Input required value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} />
              </div>
              <div className="space-y-2">
                <Label>Apellido</Label>
                <Input required value={form.lastname} onChange={(e) => setForm({ ...form, lastname: e.target.value })} />
              </div>
            </div>
            <div className="space-y-2">
              <Label>Dirección</Label>
              <Input required value={form.address} onChange={(e) => setForm({ ...form, address: e.target.value })} />
            </div>
            <div className="grid grid-cols-2 gap-3">
              <div className="space-y-2">
                <Label>Teléfono</Label>
                <Input required value={form.phone} onChange={(e) => setForm({ ...form, phone: e.target.value })} />
              </div>
              <div className="space-y-2">
                <Label>Email</Label>
                <Input required type="email" value={form.email} onChange={(e) => setForm({ ...form, email: e.target.value })} />
              </div>
            </div>
            <DialogFooter>
              <Button type="button" variant="outline" onClick={() => setOpen(false)}>Cancelar</Button>
              <Button type="submit" disabled={submitting} className="bg-primary text-primary-foreground">
                {submitting ? "Guardando..." : editId != null ? "Actualizar" : "Guardar cliente"}
              </Button>
            </DialogFooter>
          </form>
        </DialogContent>
      </Dialog>

      <Card className="border-border shadow-soft">
        <CardContent className="p-0">
          {loading && <LoadingState />}
          {error && !loading && <div className="p-6"><ErrorState message={error} /></div>}
          {!loading && !error && data.length === 0 && <EmptyState message="No hay clientes registrados" icon={<Users className="h-6 w-6" />} />}
          {!loading && !error && data.length > 0 && (
            <Table>
              <TableHeader>
                <TableRow className="bg-muted/50">
                  <TableHead>Cliente</TableHead>
                  <TableHead className="hidden md:table-cell">Contacto</TableHead>
                  <TableHead className="hidden lg:table-cell">Dirección</TableHead>
                  <TableHead className="text-right w-32">Acciones</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {data.map((c) => (
                  <TableRow key={c.id}>
                    <TableCell>
                      <div className="font-medium text-foreground">{c.name} {c.lastname}</div>
                      <div className="text-xs text-muted-foreground">ID #{c.id}</div>
                    </TableCell>
                    <TableCell className="hidden md:table-cell">
                      <div className="flex items-center gap-1.5 text-sm"><Mail className="h-3.5 w-3.5 text-amber" /> {c.email}</div>
                      <div className="flex items-center gap-1.5 text-sm text-muted-foreground"><Phone className="h-3.5 w-3.5" /> {c.phone}</div>
                    </TableCell>
                    <TableCell className="hidden lg:table-cell text-sm text-muted-foreground">
                      <div className="flex items-center gap-1.5"><MapPin className="h-3.5 w-3.5" /> {c.address}</div>
                    </TableCell>
                    <TableCell className="text-right">
                      <div className="flex justify-end gap-1">
                        <Button variant="ghost" size="icon" onClick={() => openEdit(c)} className="text-amber hover:bg-amber/10 hover:text-wood-dark">
                          <Pencil className="h-4 w-4" />
                        </Button>
                        <ConfirmDelete itemLabel={`a ${c.name}`} onConfirm={() => remove(c.id)} />
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
