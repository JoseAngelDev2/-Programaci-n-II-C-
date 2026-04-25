import { Button } from "@/components/ui/button";
import { Pencil } from "lucide-react";
import { ReactNode } from "react";

interface Props {
  onClick: () => void;
  trigger?: ReactNode;
}

export function EditButton({ onClick, trigger }: Props) {
  if (trigger) {
    return <span onClick={onClick}>{trigger}</span>;
  }
  return (
    <Button
      variant="ghost"
      size="icon"
      onClick={onClick}
      className="text-amber hover:bg-amber/10 hover:text-wood-dark"
    >
      <Pencil className="h-4 w-4" />
    </Button>
  );
}
