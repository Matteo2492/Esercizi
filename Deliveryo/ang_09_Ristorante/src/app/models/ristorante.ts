import { Piatto } from "./piatto";

export class Ristorante {
  cod: string | undefined;
  nom: string | undefined;
  tipCuc: string | undefined;
  des: string | undefined;
  oraApe: string | undefined;
  oraChi: string | undefined;
  men: Piatto[] | undefined;
}
