function Elimina(varCodice) {
    $.ajax(
        {
            url: "/Home/Elimina/" + varCodice,
            type: "DELETE",
            success: function (risultato) {
                alert("Impiegato eliminato con successo");
                location.reload();
            },
            error: function (errore) {
                alert(errore)
            }
        }
    )
}