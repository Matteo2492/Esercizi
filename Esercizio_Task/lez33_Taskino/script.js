const stampaTabella = () => {
  $.ajax({
    url: "https://localhost:7296/api/prodotti",
    type: "GET",
    success: function (risultato) {
      let contenuto = "";
      for (let [idx, item] of risultato.entries()) {
        contenuto += `
              <tr>
                  <td>${item.nome}</td>
                  <td>${item.descrizione}</td>
                  <td>${item.prezzo}</td>
                  <td>${item.quantita}
                  <button class='ml-3 btn btn-primary' onclick="aumenta(this)">+</button>
                  <label for="riferimento_${item.nome}">Aggiorna quantità</label>
                  <input class='width-30' type='number' id='riferimento_${item.nome}' placeholder='' value='0'/>
                  <button class='btn btn-secondary' onclick="decrementa(this)">-</button>
                  <button class='btn btn-success' onclick="aggiornaQuantita('${item.nome}','${item.codice}')">Aggiorna</button>
                  </td>
                  <td>${item.categoria}</td>
                  <td>
                    <button class="btn btn-outline-warning" onclick="modifica(${idx})">Modifica</button>
                  </td>
                  <td>
                      <button class='btn btn-danger' onclick="elimina('${item.codice}')">Elimina</button>
                  </td>
              </tr>
          `;
      }
      $("#corpo-tabella").html(contenuto);
      console.log("SUCCESSO");
    },
    error: function (errore) {
      console.log(errore);
      alert("ERRORE");
    },
  });
};

const update = () => {
  let nom = $("#update-nome").val();
  let desc = $("#update-descrizione").val();
  let prez = $("#update-prezzo").val();
  let quan = $("#update-quantita").val();
  let cat = $("#update-categoria").val();
  let cod = $("#modaleModifica").data("identificativo");
  $.ajax({
    url: "https://localhost:7296/api/prodotti",
    type: "PATCH",
    data: JSON.stringify({
      codice: cod,
      nome: nom,
      descrizione: desc,
      prezzo: prez,
      quantita: quan,
      categoria: cat,
    }),
    contentType: "application/json",
    dataType: "json",
    success: function () {
      alert("OK");
      stampaTabella();
    },
    error: function (errore) {
      alert(errore);
    },
  });

  $("#modaleModifica").modal("hide");
};
const modifica = (indice) => {
  $.ajax({
    url: "https://localhost:7296/api/prodotti",
    type: "GET",
    success: function (risultato) {
      $("#update-nome").val(risultato[indice].nome);
      $("#update-descrizione").val(risultato[indice].descrizione);
      $("#update-prezzo").val(risultato[indice].prezzo);
      $("#update-quantita").val(risultato[indice].quantita);
      $("#update-categoria").val(risultato[indice].categoria);

      $("#modaleModifica").data("identificativo", risultato[indice].codice);
      $("#modaleModifica").modal("show");
    },
    error: function (errore) {
      console.log(errore);
      alert("ORRORE!!");
    },
  });
};
const aumenta = (element) => {
  let span = $(element).siblings("input");

  let numeroAttuale = span.val();

  numeroAttuale++;

  span.val(numeroAttuale);
};
const decrementa = (element) => {
  let span = $(element).siblings("input");

  let numeroAttuale = span.val();

  numeroAttuale--;

  if (numeroAttuale < 0) {
    numeroAttuale = 0;
  }

  span.val(numeroAttuale);
};
const elimina = (codice) => {
  $.ajax({
    url: "https://localhost:7296/api/prodotti/codice/" + codice,
    type: "DELETE",
    success: function () {
      stampaTabella();
    },
    error: function (errore) {
      alert("Errore tremendo!!");
      console.log(errore);
    },
  });
};
const aggiornaQuantita = (nome, codice) => {
  let quant = $(`#riferimento_${nome}`).val();
  let cod = codice;
  $.ajax({
    url: "https://localhost:7296/api/prodotti",
    type: "PATCH",
    data: JSON.stringify({
      codice: cod,
      nome: null,
      descrizione: null,
      prezzo: 0,
      quantita: quant,
      categoria: null,
    }),
    contentType: "application/json",
    dataType: "json",
    success: function () {
      alert("Aggiornamento quantita avvenuto");
      stampaTabella();
    },
    error: function (errore) {
      alert(errore);
    },
  });
};

const salvaElemento = () => {
  let nom = $("#input-nome").val();
  let desc = $("#input-descrizione").val();
  let prez = $("#input-prezzo").val();
  let quan = $("#input-quantita").val();
  let cat = $("#input-categoria").val();

  $.ajax({
    url: "https://localhost:7296/api/prodotti",
    type: "POST",
    data: JSON.stringify({
      nome: nom,
      descrizione: desc,
      prezzo: prez,
      quantita: quan,
      categoria: cat,
    }),
    contentType: "application/json",
    dataType: "json",
    success: function () {
      alert("OK");
      stampaTabella();
    },
    error: function (errore) {
      alert(errore);
    },
  });
};

$(document).ready(function () {
  stampaTabella();
  $(".salva").on("click", () => {
    salvaElemento();
  });
});
