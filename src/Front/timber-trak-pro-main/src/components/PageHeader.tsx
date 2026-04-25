import { ReactNode } from "react";

interface PageHeaderProps {
  title: string;
  description?: string;
  icon?: ReactNode;
  action?: ReactNode;
}

export function PageHeader({ title, description, icon, action }: PageHeaderProps) {
  return (
    <div className="flex flex-col md:flex-row md:items-end md:justify-between gap-4 mb-8">
      <div className="flex items-start gap-4">
        {icon && (
          <div className="flex h-12 w-12 items-center justify-center rounded-lg bg-gradient-wood shadow-warm text-amber">
            {icon}
          </div>
        )}
        <div>
          <h1 className="text-3xl md:text-4xl font-display font-bold text-foreground">
            {title}
          </h1>
          {description && (
            <p className="text-muted-foreground mt-1 max-w-xl">{description}</p>
          )}
        </div>
      </div>
      {action && <div className="shrink-0">{action}</div>}
    </div>
  );
}
