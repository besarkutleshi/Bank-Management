

function ChangeActionFormToSaving() {
    var form = document.getElementById("accountform");
    form.attr('action', 'InsertSavingAccount');
    console.log('changed')
}