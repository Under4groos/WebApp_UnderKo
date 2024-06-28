





function event_copy_textbox_(nameinput , namebutton) {
    $(namebutton).tooltip();

    $(namebutton).bind('click', function () {
        var input = document.querySelector(nameinput);
        input.select();
        navigator.clipboard.writeText(input.value);
        alert("Copied the text: " + input.value);

    });
}


 