import { ReactNode } from "react";
import { Inbox } from "lucide-react";

export function EmptyState({ message = "Sin registros aún", icon }: { message?: string; icon?: ReactNode }) {
  return (
    <div className="flex flex-col items-center justify-center py-16 text-muted-foreground">
      <div className="h-14 w-14 rounded-full bg-muted flex items-center justify-center mb-3">
        {icon ?? <Inbox className="h-6 w-6" />}
      </div>
      <p className="text-sm">{message}</p>
    </div>
  );
}

export function LoadingState() {
  return (
    <div className="flex items-center justify-center py-16">
      <div className="h-8 w-8 rounded-full border-2 border-amber border-t-transparent animate-spin" />
    </div>
  );
}

export function ErrorState({ message }: { message: string }) {
  return (
    <div className="rounded-lg border border-destructive/30 bg-destructive/5 p-6 text-sm text-destructive">
      <div className="font-semibold mb-1">No se pudo cargar la información</div>
      <div className="text-destructive/80">{message}</div>
      <div className="text-muted-foreground mt-3 text-xs">
        Verifica que el backend esté corriendo en <code className="font-mono">https://localhost:7000</code> y que CORS esté habilitado.
      </div>
    </div>
  );
}
