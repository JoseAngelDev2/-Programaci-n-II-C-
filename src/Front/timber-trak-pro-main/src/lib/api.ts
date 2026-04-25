// API client for Caspentry Workshop backend
// IMPORTANT: change this if your backend runs on a different host/port.
// Note: the backend must allow CORS for this origin.
export const API_BASE_URL = "https://localhost:7122";

async function request<T>(path: string, options: RequestInit = {}): Promise<T> {
  const res = await fetch(`${API_BASE_URL}${path}`, {
    headers: { "Content-Type": "application/json", Accept: "application/json" },
    ...options,
  });
  if (!res.ok) {
    let msg = `${res.status} ${res.statusText}`;
    try {
      const body = await res.text();
      if (body) msg += ` — ${body}`;
    } catch {}
    throw new Error(msg);
  }
  if (res.status === 204) return undefined as T;
  const text = await res.text();
  return text ? (JSON.parse(text) as T) : (undefined as T);
}

// ---------- Types ----------
export interface Client {
  id: number;
  name: string;
  lastname: string;
  address: string;
  phone: string;
  email: string;
}
export type AddClientDto = Omit<Client, "id">;

export interface Project {
  id: number;
  nameProyect: string;
  description: string;
  status: string;
  total: number;
  clienteId: number;
}
export type AddProjectDto = Omit<Project, "id">;

export interface Carpinter {
  id: number;
  name: string;
  specialty: string;
  phone: string;
  salary: number;
}
export type AddCarpinterDto = Omit<Carpinter, "id">;

export interface Material {
  id: number;
  nombreMaterial: string;
  cantidad: number;
  precioUnitario: number;
  imageMaterial: string;
}
export type AddMaterialDto = Omit<Material, "id">;

export interface Delivery {
  id: number;
  deliveryDate: string;
  statusDelivery: "Pendiente" | "Entregado" | string;
  projectId: number;
}
export type AddDeliveryDto = Omit<Delivery, "id">;

// ---------- Generic CRUD factory ----------
function crud<T, Add>(resource: string) {
  return {
    list: () => request<T[]>(`/api/${resource}`),
    get: (id: number) => request<T>(`/api/${resource}/${id}`),
    create: (dto: Add) =>
      request<T>(`/api/${resource}`, { method: "POST", body: JSON.stringify(dto) }),
    update: (id: number, dto: Add) =>
      request<T>(`/api/${resource}/${id}`, { method: "PUT", body: JSON.stringify({ id, ...dto }) }),
    remove: (id: number) =>
      request<void>(`/api/${resource}/${id}`, { method: "DELETE" }),
  };
}

export const ClientsApi = crud<Client, AddClientDto>("Client");
export const ProjectsApi = crud<Project, AddProjectDto>("Project");
export const CarpintersApi = crud<Carpinter, AddCarpinterDto>("Carpinter");
export const MaterialsApi = crud<Material, AddMaterialDto>("Material");
export const DeliveriesApi = crud<Delivery, AddDeliveryDto>("Delivery");
