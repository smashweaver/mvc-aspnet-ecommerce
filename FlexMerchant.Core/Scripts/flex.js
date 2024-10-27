/*  Author: Jason Jimenez 
 *    Date: March 2008
 * Purpose: A simple framework to support dynamic loading/unloading of partial views 
 */

flex = new function() {
    this.parts = new Array();
    this.scripts = new Array();
    this.callbacks = new Array();
    this.forms = new Array();
}

flex.getXMLHttpRequest = function() { 
    var req = null;
    if (window.XMLHttpRequest)   {
        req = new XMLHttpRequest();
    }  
    else  
    {
        if (window.flex_XMLHttpRequestProgID) {
            req = new ActiveXObject(window.flex_XMLHttpRequestProgID);
        }  
        else  
        {
            var progIDs = ["Msxml2.XMLHTTP.6.0", "Msxml2.XMLHTTP.5.0", "Msxml2.XMLHTTP.4.0", "MSXML2.XMLHTTP.3.0", "MSXML2.XMLHTTP", "Microsoft.XMLHTTP"];
	        for (var i = 0; i < progIDs.length; ++i)  
	        {
		        var progID = progIDs[i];
		        try   {
			        req = new ActiveXObject(progID);
			        window.flex_XMLHttpRequestProgID = progID;
			        break;
		        } catch (e)  {}
	        }
        }
    }
    return req;
}

flex.ajax = function(url, method, success, error) {
    var request = flex.getXMLHttpRequest();
    var headers = [];
    var callback = function() {
        if(request.readyState == 4)  {
            if(request.status == 200) 
                success ? success(request.responseText) : null;
            else 
                error ? error(request.responseText) : null;
        }
    };
    return {
        setHeader : function(key, value) { 
            headers.push({Key:key, Value:value});
        },
        send : function(data) {  
            request.open(method, url, true);
            request.onreadystatechange = callback;
            this.setHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
            this.setHeader("Accept-Encoding", "gzip, deflate");
            for(i=0; i<headers.length; i++) {
                var header = headers[i];
                request.setRequestHeader(header.Key, header.Value);
            }
            request.send(data); 
        }
    }
}

flex.partCall = function(part, target) {
    var success = function(data) {
        var el = document.getElementById(target);        
        el.innerHTML = data;
    }             
    var req = flex.ajax("/@getpart", "post", success);
    req.setHeader("AjaxPart", part);
    req.send("");
}

flex.ajaxCall = function(form, target) {
    var success = function(data) {
        var el = document.getElementById(target);
        el.innerHTML = data;  
    }
        
    var method = "";
    if (form.method) method = form.method;
    else method = "post";
    
    var req = flex.ajax(form.action, method, success, null);
    var data = flex.getData(form);
    req.setHeader("Ajax", form.id);
    req.send(data);
}

flex.jsonCall = function(url, target) {
    var success = function(data) {
        var el = document.getElementById(target);
        el.innerHTML = data; 
    }             
    var request = flex.ajax(url, "post", success, null);
    request.setHeader("Json", "flex");
    request.send("");
}

flex.getData = function(form) {
    var pairs = [];
    for(i=0; i<form.elements.length; i++) {
        var el = form.elements[i];
        pairs[i] = flex.valuePair(el.name, el.value);
    }
    return flex.serialize(pairs);
}

flex.submitForm = function(form, returnUrl) {   
    var _success = function(){ if(returnUrl) location.href=returnUrl; flex.refresh();};
    var _request = flex.ajax(form.action, form.method, _success, null);
    _request.setHeader("Ajax","flex");
    _request.send(flex.getData(form));
}

flex.eval = function(arg) {
    return eval('('+arg+')');
}
    
flex.valuePair = function(mname, mvalue) {
    return {
        name : mname,
        value : mvalue,
        toArray : function() {var arr = new Array(); arr.push(this); return arr;}
    }
}

flex.serialize = function(pairs) {
    var queryString = [];
    for(i=0; i<pairs.length; i++)
    {
        var el = pairs[i];
        var name = el.name;
        var value = el.value;
        if (!name || !value) break;
	    var add = function(val) {
		    queryString.push(name + '=' + encodeURIComponent(val));
        };	
        if (value.push) 
            for(j=0; j<value.length; j++) { add(value[j]); }
        else  
            add(value);			    
    }
    return queryString.join('&');
}


flex.addScript = function(script) {
    flex.scripts.push(script);
}

flex.loadScripts = function() {
    flex.scripts.reverse();
    while (flex.scripts.length>0) {
        var func = flex.scripts.pop();
        func();
    }
}


flex.addPart = function(thePart, theTarget) {  
    flex.parts.push({Part:thePart, Target:theTarget});
}

flex.removePart = function(thepart) {
    var index = -1;
    for(var i=0; i<flex.parts.length; i++) {
        var p = flex.parts[i];
        if (p.Part == thepart) {
            index = i;
            break;
        }
    }
    if (index>=0) flex.parts.splice(index,1);    
}

flex.removePartElement = function(part) {
    var el = document.getElementById(part.Target);
    document.removeChild(el);
}

flex.unloadPart = function(part) {
    flex.addScript(function(){
        flex.removePart(part); 
    });
}

flex.loadParts = function() {
    for(var i=0; i<flex.parts.length; i++) {
        var part = flex.parts[i];
        flex.partCall(part.Part, part.Target);
    }
}

flex.refresh = function() {
    flex.loadParts();
}

window.onload = function() {
    flex.loadScripts();
    flex.refresh();
}


