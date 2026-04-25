import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Users, Briefcase, Package, Truck, Hammer, TrendingUp, LayoutDashboard } from "lucide-react";
import { ClientsApi, ProjectsApi, MaterialsApi, DeliveriesApi, CarpintersApi } from "@/lib/api";
import { PageHeader } from "@/components/PageHeader";
import { ErrorState, LoadingState } from "@/components/EmptyState";

interface Stats {
  clients: number;
  activeProjects: number;
  materials: number;
  pendingDeliveries: number;
  carpenters: number;
  totalRevenue: number;
}

const ACTIVE_PROJECT = ["en progreso", "pendiente"];

export default function Dashboard() {
  const [stats, setStats] = useState<Stats | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    (async () => {
      try {
        const [c, p, m, d, k] = await Promise.all([
          ClientsApi.list(),
          ProjectsApi.list(),
          MaterialsApi.list(),
          DeliveriesApi.list(),
          CarpintersApi.list(),
        ]);
        setStats({
          clients: c.length,
          activeProjects: p.filter((x) => ACTIVE_PROJECT.includes((x.status || "").toLowerCase())).length,
          materials: m.length,
          pendingDeliveries: d.filter((x) => (x.statusDelivery || "").toLowerCase() === "pendiente").length,
          carpenters: k.length,
          totalRevenue: p.reduce((sum, x) => sum + (x.total || 0), 0),
        });
      } catch (e) {
        setError(e instanceof Error ? e.message : "Error");
      } finally {
        setLoading(false);
      }
    })();
  }, []);

  const cards = [
    { label: "Clientes", value: stats?.clients ?? 0, icon: Users, accent: "from-amber to-amber-glow" },
    { label: "Proyectos activos", value: stats?.activeProjects ?? 0, icon: Briefcase, accent: "from-wood-mid to-wood-light" },
    { label: "Carpinteros", value: stats?.carpenters ?? 0, icon: Hammer, accent: "from-amber/80 to-amber" },
    { label: "Materiales", value: stats?.materials ?? 0, icon: Package, accent: "from-wood-dark to-wood-mid" },
    { label: "Entregas pendientes", value: stats?.pendingDeliveries ?? 0, icon: Truck, accent: "from-amber-glow to-amber" },
    { label: "Total facturado", value: `$${(stats?.totalRevenue ?? 0).toLocaleString()}`, icon: TrendingUp, accent: "from-wood-mid to-amber" },
  ];

  return (
    <div className="max-w-7xl mx-auto">
      <PageHeader
        icon={<LayoutDashboard className="h-6 w-6" />}
        title="Dashboard"
        description="Resumen general del taller. Una mirada rápida al estado de todas las operaciones."
      />

      {loading && <LoadingState />}
      {error && !loading && <ErrorState message={error} />}

      {!loading && !error && (
        <div className="grid gap-4 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3">
          {cards.map((card) => (
            <Card key={card.label} className="border-border shadow-soft hover:shadow-warm transition-shadow overflow-hidden">
              <CardHeader className="flex flex-row items-center justify-between pb-2">
                <CardTitle className="text-sm font-medium text-muted-foreground">{card.label}</CardTitle>
                <div className={`h-10 w-10 rounded-md bg-gradient-to-br ${card.accent} flex items-center justify-center text-wood-dark shadow-soft`}>
                  <card.icon className="h-5 w-5" />
                </div>
              </CardHeader>
              <CardContent>
                <div className="text-3xl font-display font-bold text-foreground">{card.value}</div>
              </CardContent>
            </Card>
          ))}
        </div>
      )}

      <Card className="mt-8 border-border bg-gradient-wood text-amber shadow-warm">
        <CardContent className="py-6 px-6 flex items-center gap-4">
          <Hammer className="h-8 w-8 shrink-0" />
          <div>
            <div className="font-display text-lg font-semibold">Bienvenido a Caspentry Workshop</div>
            <div className="text-sm text-amber/80">
              Gestiona clientes, proyectos, carpinteros, materiales y entregas desde un solo lugar.
            </div>
          </div>
        </CardContent>
      </Card>
    </div>
  );
}
