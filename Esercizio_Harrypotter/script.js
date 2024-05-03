const stampa = () => {
  let elenco = JSON.parse(localStorage.getItem("bacchette"));

  let stringaTabella = "";
  for (let [idx, item] of elenco.entries()) {
    stringaTabella += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.codice}</td>
                <td>${item.materiale}</td>
                <td>${item.nucleo}</td>
                <td>${item.lunghezza}</td>
                <td>${item.resistenza}</td>
                <td>${item.nomeMago}</td>
                <td>${item.casata}</td>
                <td><img src='${item.linkImg}' width='100' height='100' /></td>
                <td class="text-right">
                    <button class="btn btn-outline-warning" onclick="modifica(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button>
                    <button class="btn btn-outline-danger" onclick="elimina(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;
  }

  document.getElementById("corpo-tabella").innerHTML = stringaTabella;
};

const stampaCasata = () => {
  let elenco = JSON.parse(localStorage.getItem("casate"));
  let elencoBacchette = JSON.parse(localStorage.getItem("bacchette"));
  for (const casata of elenco) {
    for (const bacchetta of elencoBacchette) {
      if (bacchetta.casata == casata.nome) {
        casata.numerobacchette++;
      }
    }
  }
  let stringaTabella = "";
  for (let [idx, item] of elenco.entries()) {
    stringaTabella += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.nome}</td>
                <td>${item.descrizione}</td>
                <td><img src='${item.logo}' width='100' height='100' /></td>
                <td>${item.numerobacchette}</td>
                <td class="text-right">
                    <button class="btn btn-outline-warning" onclick="modificaCasate(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button>
                    <button class="btn btn-outline-danger" onclick="eliminaCasata(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;
  }

  document.getElementById("corpo-tabella-casate").innerHTML = stringaTabella;
};

const salva = () => {
  let codice = document.getElementById("input-codice").value;
  let materiale = document.getElementById("select-materiale").value;
  let nucleo = document.getElementById("select-nucleo").value;
  let lunghezza = document.getElementById("input-lunghezza").value;
  let resistenza = document.getElementById("select-resistenza").value;
  let nomeMago = document.getElementById("input-nome").value;
  let casata = document.getElementById("select-casata").value;
  let linkImg = document.getElementById("input-img").value;

  let ogg = {
    codice,
    materiale,
    nucleo,
    lunghezza,
    resistenza,
    nomeMago,
    casata,
    linkImg,
  };

  let elenco = JSON.parse(localStorage.getItem("bacchette"));
  elenco.push(ogg);
  localStorage.setItem("bacchette", JSON.stringify(elenco));

  let elencoCasate = JSON.parse(localStorage.getItem("casate"));
  for (let [idx, item] of elencoCasate.entries()) {
    if (item.nome == casata) {
      item.numerobacchette++;
    }
  }

  document.getElementById("input-codice").value = "";
  document.getElementById("select-materiale").value = "";
  document.getElementById("select-nucleo").value = "";
  document.getElementById("input-lunghezza").value = "";
  document.getElementById("select-resistenza").value = "";
  document.getElementById("input-nome").value = "";
  document.getElementById("select-casata").value = "";
  document.getElementById("input-img").value = "";

  stampa();

  $("#modaleInserimento").modal("hide");
};

const salvaCasata = () => {
  let nome = document.getElementById("input-nome-casata").value;
  let descrizione = document.getElementById("input-descrizione").value;
  let logo = document.getElementById("input-logo").value;

  let ogg = {
    nome,
    descrizione,
    logo,
  };

  let elenco = JSON.parse(localStorage.getItem("casate"));
  elenco.push(ogg);
  localStorage.setItem("casate", JSON.stringify(elenco));

  document.getElementById("input-nome-casata").value = "";
  document.getElementById("input-descrizione").value = "";
  document.getElementById("input-logo").value = "";

  stampaCasata();

  $("#modaleInserimento-casata").modal("hide");
};
const InserimentoIniziale = () => {
  let elenco = JSON.parse(localStorage.getItem("casate"));
  if (elenco.length < 4) {
    elenco.splice(0, 4);
    let ogg = {
      nome: "Grifondoro",
      descrizione: "Poco virili",
      logo: "https://i.pinimg.com/736x/5e/89/88/5e89889df44a4a0782851eba00012434.jpg",
      numerobacchette: 0,
    };
    let ogg2 = {
      nome: "Serpeverde",
      descrizione: "Poco simpatici",
      logo: "https://th.bing.com/th/id/OIP.s1SJDym5NzB2lI8Kw0iCEQHaJB?rs=1&pid=ImgDetMain",
      numerobacchette: 0,
    };
    let ogg3 = {
      nome: "Tassorosso",
      descrizione: "Poco conosciuti",
      logo: "https://th.bing.com/th/id/OIP.VeBF-CupIV1QMO9a6WUycQHaHa?rs=1&pid=ImgDetMain",
      numerobacchette: 0,
    };
    let ogg4 = {
      nome: "Corvonero",
      descrizione: "Poco sociali",
      logo: "https://th.bing.com/th/id/R.4f9425be62f7df3560ed3c3e7353da29?rik=N0m0aJR1SWeoWQ&pid=ImgRaw&r=0",
      numerobacchette: 0,
    };
    elenco.push(ogg);
    elenco.push(ogg2);
    elenco.push(ogg3);
    elenco.push(ogg4);
    localStorage.setItem("casate", JSON.stringify(elenco));
  }
};
const dropDownCasate = () => {
  let elenco = JSON.parse(localStorage.getItem("casate"));
  let stringaTabella =
    "<option value'Scegli una casata'>Scegli una casata</option>";
  for (let [idx, value] of elenco.entries()) {
    stringaTabella += `
        <option value='${value.nome}'>${value.nome}</option>
    `;
  }
  document.getElementById("update-casata").innerHTML = stringaTabella;
  document.getElementById("select-casata").innerHTML = stringaTabella;
};
const elimina = (indice) => {
  let elenco = JSON.parse(localStorage.getItem("bacchette"));
  elenco.splice(indice, 1);
  localStorage.setItem("bacchette", JSON.stringify(elenco));

  stampa();
};
const eliminaCasata = (indice) => {
  let elenco = JSON.parse(localStorage.getItem("casate"));
  elenco.splice(indice, 1);
  localStorage.setItem("casate", JSON.stringify(elenco));

  stampaCasata();
};
const modifica = (indice) => {
  let elenco = JSON.parse(localStorage.getItem("bacchette"));
  console.log(elenco[indice]);

  document.getElementById("update-codice").value = elenco[indice].codice;
  document.getElementById("update-materiale").value = elenco[indice].materiale;
  document.getElementById("update-nucleo").value = elenco[indice].nucleo;
  document.getElementById("update-lunghezza").value = elenco[indice].lunghezza;
  document.getElementById("update-resistenza").value =
    elenco[indice].resistenza;
  document.getElementById("update-nome").value = elenco[indice].nomeMago;
  document.getElementById("update-casata").value = elenco[indice].casata;
  document.getElementById("update-img").value = elenco[indice].linkImg;

  $("#modaleModifica").data("identificativo", indice);

  $("#modaleModifica").modal("show");
};
const modificaCasate = (indice) => {
  let elenco = JSON.parse(localStorage.getItem("casate"));
  console.log(elenco[indice]);

  document.getElementById("update-nome-casata").value = elenco[indice].nome;
  document.getElementById("update-descrizione").value =
    elenco[indice].descrizione;
  document.getElementById("update-logo").value = elenco[indice].logo;

  $("#modaleModifica-casata").data("identificativo-casata", indice);

  $("#modaleModifica-casata").modal("show");
};
const update = () => {
  let codice = document.getElementById("update-codice").value;
  let materiale = document.getElementById("update-materiale").value;
  let nucleo = document.getElementById("update-nucleo").value;
  let lunghezza = document.getElementById("update-lunghezza").value;
  let resistenza = document.getElementById("update-resistenza").value;
  let nomeMago = document.getElementById("update-nome").value;
  let casata = document.getElementById("update-casata").value;
  let linkImg = document.getElementById("update-img").value;

  let ogg = {
    codice,
    materiale,
    nucleo,
    lunghezza,
    resistenza,
    nomeMago,
    casata,
    linkImg,
  };

  let indice = $("#modaleModifica").data("identificativo");

  let elenco = JSON.parse(localStorage.getItem("bacchette"));
  elenco[indice] = ogg;
  localStorage.setItem("bacchette", JSON.stringify(elenco));

  $("#modaleModifica").modal("hide");
};
const updateCasata = () => {
  let nome = document.getElementById("update-nome-casata").value;
  let descrizione = document.getElementById("update-descrizione").value;
  let logo = document.getElementById("update-logo").value;

  let ogg = {
    nome,
    descrizione,
    logo,
  };

  let indice = $("#modaleModifica-casata").data("identificativo-casata");

  let elenco = JSON.parse(localStorage.getItem("casate"));
  elenco[indice] = ogg;
  localStorage.setItem("casate", JSON.stringify(elenco));

  $("#modaleModifica-casate").modal("hide");
};
