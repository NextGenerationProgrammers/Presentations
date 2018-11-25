

const script = document.currentScript;
const scriptURL = script.src;

String.prototype.isEmpty = function() {
    return (!this || 0 === this.length);
}
String.prototype.format = function() {
    a = this;
    for (k in arguments) {
        a = a.replace("{" + k + "}", arguments[k])
    }
    return a
}

class Quizy {

    constructor() {
        this.btnType = 'btn-';
        this.clearTxt = 'Clear';
        this.submitTxt = 'Submit';
        this.errorTxt = '{0} Error(s)';
        this.solvedTxt = 'Solved';
    }

    initGUI() {
        var self = this;
        $('.quiz > .answer').each(function(){
            $(this).addClass('started btn ' + self.btnType + 'secondary');
        });
        $('.quiz > h5').each(function(){
            $(this).addClass('card-title');
        });
        $('.quiz').append('<p class="result"></p>');
        $('.quiz').append('<button class="clear btn btn-danger">' + self.clearTxt + '</button>');
        $('.quiz').append(' <button class="submit btn btn-primary">' + self.submitTxt + '</button>');
        $('.quiz').each(function(){
            $(this).addClass('card border border-dark bg-dark-transparent');
            var inner = '<div class="card-body">';
            inner += $(this).html();
            inner += '</div>';
            $(this).html(inner);
        });
    }

    removeChecked(obj) {
        obj.removeClass('checked tested ' + this.btnType + 'warning ' + this.btnType + 'success ' + this.btnType + 'danger');
        obj.addClass('started ' + this.btnType + 'secondary');
    }

    isSubmitted(parent) {
        return !parent.children('.result').first().html().isEmpty();
    }

    initEvent() {
        var self = this;
        // answer clicked
        $('.quiz > > .answer').click(function() {
            if (self.isSubmitted($(this).parent())) {
                return;
            }
            if ($(this).hasClass('started')) {
                $(this).removeClass('started ' + self.btnType + 'secondary');
                $(this).addClass('checked ' + self.btnType + 'warning');
            }
            else if ($(this).hasClass('checked')) {
                self.removeChecked($(this));
            }
        });
        // submit clicked
        $('.quiz > > .submit').click(function() {
            var answers = $(this).parent().children('.answer');
            var errorCounter = 0;
            answers.each(function() {
                if ($(this).hasClass('checked')) {
                    if ($(this).hasClass('true')) {
                        $(this).removeClass('checked ' + self.btnType + 'warning');
                        $(this).addClass('tested ' + self.btnType + 'success');
                    }
                    else if ($(this).hasClass('false')) {
                        $(this).removeClass('checked ' + self.btnType + 'warning');
                        $(this).addClass('tested ' + self.btnType + 'danger');
                        errorCounter += 1;
                    }
                }
                else if ($(this).hasClass('true')) {
                    errorCounter += 1;
                }
            });
            if (errorCounter != 0) {
                 $(this).parent().children('.result').first().html(self.errorTxt.format(errorCounter.toString()));
            }
            else {
                 $(this).parent().children('.result').first().html(self.solvedTxt);
            }
        });
        // clear clicked
        $('.quiz > > .clear').click(function() {
            var answers = $(this).parent().children('.answer');
            var errorCounter = 0;
            answers.each(function() {
                self.removeChecked($(this));
            });
            $(this).parent().children('.result').first().html('');
        });
    }

    initDependency() {
        const styleSheet = scriptURL + '../../../css/quizy.css';
        this.loadCSS(styleSheet);

    }

    loadCSS(href, callback) {
        var head = document.getElementsByTagName('head')[0];

        var style = document.createElement('link');
        style.href = href;
        style.type = 'text/css';
        style.rel = 'stylesheet';

        if (callback instanceof Function) {
            style.onload = function() {
                callback();
            };
        }

        head.append(style);
    }

    init(config) {
        if ('outline' in config) {
            if (config['outline']) {
                this.btnType += 'outline-';
            }
        }
        if ('submitTxt' in config) {
            this.submitTxt = config['submitTxt'];
        }
        if ('clearTxt' in config) {
            this.clearTxt = config['clearTxt'];
        }
        if ('errorTxt' in config) {
            this.errorTxt = config['errorTxt'];
        }
        if ('solvedTxt' in config) {
            this.solvedTxt = config['solvedTxt'];
        }
        this.initDependency();
        this.initGUI();
        this.initEvent();
    }
}

var quizy = new Quizy();
