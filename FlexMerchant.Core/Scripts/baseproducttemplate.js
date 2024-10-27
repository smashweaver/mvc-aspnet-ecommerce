function __callProduct(id)
{
    var f = document.forms["productForm"];
    var elId = f.elements["id"];
    elId.value = id;
    f.submit();
}