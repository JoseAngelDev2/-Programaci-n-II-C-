import { Outlet } from "react-router-dom";
import { SidebarProvider, SidebarTrigger } from "@/components/ui/sidebar";
import { AppSidebar } from "./AppSidebar";

export default function AppLayout() {
  return (
    <SidebarProvider>
      <div className="min-h-screen flex w-full bg-background">
        <AppSidebar />
        <div className="flex-1 flex flex-col min-w-0">
          <header className="h-14 flex items-center gap-3 border-b border-border bg-card/80 backdrop-blur px-4 sticky top-0 z-30">
            <SidebarTrigger className="text-foreground" />
            <div className="h-5 w-px bg-border" />
            <div className="text-sm text-muted-foreground">
              Sistema de gestión · <span className="text-foreground font-medium">Caspentry Workshop</span>
            </div>
          </header>
          <main className="flex-1 p-4 md:p-8 animate-fade-in">
            <Outlet />
          </main>
        </div>
      </div>
    </SidebarProvider>
  );
}
