function txtData_KeyPress( obj, e )
{
    var whichCode = (window.Event) ? e.which : e.keyCode;	   
    if (whichCode >= 48 && whichCode <= 57)
    {
		if (obj.value.length == 2)
		    obj.value = obj.value + '/';
		if (obj.value.length == 5)
		    obj.value = obj.value + '/';
		return true;  // Enter
	}
	else
	{
		return false;
	}
}