import { NavLink, useLocation } from "react-router-dom";
import { LayoutDashboard, Users, Hammer, Package, Truck, Briefcase, Axe } from "lucide-react";
import {
  Sidebar,
  SidebarContent,
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  SidebarHeader,
  SidebarFooter,
  useSidebar,
} from "@/components/ui/sidebar";

const items = [
  { title: "Dashboard", url: "/", icon: LayoutDashboard, end: true },
  { title: "Clientes", url: "/clientes", icon: Users },
  { title: "Proyectos", url: "/proyectos", icon: Briefcase },
  { title: "Carpinteros", url: "/carpinteros", icon: Hammer },
  { title: "Materiales", url: "/materiales", icon: Package },
  { title: "Entregas", url: "/entregas", icon: Truck },
];

export function AppSidebar() {
  const { state } = useSidebar();
  const collapsed = state === "collapsed";
  const { pathname } = useLocation();

  return (
    <Sidebar collapsible="icon" className="border-r border-sidebar-border">
      <SidebarHeader className="bg-wood-grain">
        <div className="flex items-center gap-3 px-2 py-3">
          <div className="flex h-10 w-10 shrink-0 items-center justify-center rounded-md bg-gradient-amber shadow-warm">
            <Axe className="h-5 w-5 text-wood-dark" strokeWidth={2.5} />
          </div>
          {!collapsed && (
            <div className="leading-tight">
              <div className="font-display text-lg font-bold text-sidebar-foreground">
                Caspentry
              </div>
              <div className="text-[10px] uppercase tracking-[0.2em] text-amber">
                Workshop
              </div>
            </div>
          )}
        </div>
      </SidebarHeader>

      <SidebarContent className="bg-wood-grain">
        <SidebarGroup>
          <SidebarGroupLabel className="text-sidebar-foreground/50 uppercase text-[10px] tracking-widest">
            Gestión
          </SidebarGroupLabel>
          <SidebarGroupContent>
            <SidebarMenu>
              {items.map((item) => {
                const active = item.end ? pathname === item.url : pathname.startsWith(item.url);
                return (
                  <SidebarMenuItem key={item.title}>
                    <SidebarMenuButton
                      asChild
                      tooltip={item.title}
                      className={
                        active
                          ? "bg-sidebar-accent text-amber font-semibold"
                          : "text-sidebar-foreground/80 hover:bg-sidebar-accent hover:text-sidebar-accent-foreground"
                      }
                    >
                      <NavLink to={item.url} end={item.end}>
                        <item.icon className="h-4 w-4" />
                        <span>{item.title}</span>
                      </NavLink>
                    </SidebarMenuButton>
                  </SidebarMenuItem>
                );
              })}
            </SidebarMenu>
          </SidebarGroupContent>
        </SidebarGroup>
      </SidebarContent>

      <SidebarFooter className="bg-wood-grain border-t border-sidebar-border">
        {!collapsed && (
          <div className="px-3 py-2 text-[10px] text-sidebar-foreground/50">
            v1.0 · Hecho con madera y código
          </div>
        )}
      </SidebarFooter>
    </Sidebar>
  );
}
