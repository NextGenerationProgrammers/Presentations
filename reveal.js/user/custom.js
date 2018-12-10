
class Loader {
    static loadToDOM(filename, elementID) {
        $.get(filename, function(response) {
            $("#" + elementID).html(response);
            // $("code").each(function(i, block) {
            // hljs.highlightBlock(block);
            // });
        });
    }
}