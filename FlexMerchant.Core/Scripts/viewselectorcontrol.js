function __setView(view)
{
    var f = document.forms["viewForm"];
    var elView = f.elements["view"];
    var elPage  = f.elements["page"];
    elPage.value = "1";
    elView.value = view;
    f.submit();
}