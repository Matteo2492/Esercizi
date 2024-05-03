import { Piatto } from '../models/piatto';
import { Ristorante } from '../models/ristorante';

export class Risposta {
  status: string | undefined;
  data?: string | Ristorante | Ristorante[] | Piatto[] | undefined | null;
}
