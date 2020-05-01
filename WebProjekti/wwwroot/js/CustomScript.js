function confirmDelete(uniqueID, isTrue) {
    var deleteSpan = 'deleteSpan_' + uniqueID;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueID;
    if (isTrue) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }         
    else {    
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}