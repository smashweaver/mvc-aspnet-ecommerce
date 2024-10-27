function __setOrder(order)
{
    var f = document.forms["viewForm"];
     var orderElement = f.elements["order"];
     orderElement.value = order;
     f.submit();
}    