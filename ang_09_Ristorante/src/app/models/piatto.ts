import { Menu } from "./menu";

export class Piatto {
  cod: string | undefined;
  nom: string | undefined;
  des: string | undefined;
  pre: number | undefined;
  qua: number | undefined;
  menRifNav: Menu | undefined;
  ordRif: [] | undefined;
}
