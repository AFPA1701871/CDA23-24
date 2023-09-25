'use strict';
Object.defineProperty(exports, "__esModule", { value: true });
const vscode = require("vscode");
const Redirector_1 = require("./Redirector");
const Property_1 = require("./Property");
const Configuration_1 = require("./Configuration");
const TemplatesManager_1 = require("./TemplatesManager");
class Resolver {
    constructor() {
        /**
         * Types that won't be recognised as valid type hints
         */
        this.pseudoTypes = ['mixed', 'number', 'callback', 'object', 'void'];
        const editor = this.activeEditor();
        if (editor.document.languageId !== 'php') {
            throw new Error('Not a PHP file.');
        }
        this.config = new Configuration_1.default;
        this.templatesManager = new TemplatesManager_1.default;
    }
    activeEditor() {
        return vscode.window.activeTextEditor;
    }
    closingClassLine() {
        const editor = this.activeEditor();
        for (let lineNumber = editor.document.lineCount - 1; lineNumber > 0; lineNumber--) {
            const line = editor.document.lineAt(lineNumber);
            const text = line.text.trim();
            if (text.startsWith('}')) {
                return line;
            }
        }
        return null;
    }
    insertGetter() {
        const editor = this.activeEditor();
        let property = null;
        let content = '';
        for (let index = 0; index < editor.selections.length; index++) {
            const selection = editor.selections[index];
            try {
                property = Property_1.default.fromEditorPosition(editor, selection.active);
            }
            catch (error) {
                this.showErrorMessage(error.message);
                return null;
            }
            content += this.getterTemplate(property);
        }
        this.renderTemplate(content);
    }
    insertGetterAndSetter() {
        const editor = this.activeEditor();
        let property = null;
        let content = '';
        for (let index = 0; index < editor.selections.length; index++) {
            const selection = editor.selections[index];
            try {
                property = Property_1.default.fromEditorPosition(editor, selection.active);
            }
            catch (error) {
                this.showErrorMessage(error.message);
                return null;
            }
            content += this.getterTemplate(property) + this.setterTemplate(property);
        }
        this.renderTemplate(content);
    }
    insertSetter() {
        const editor = this.activeEditor();
        let property = null;
        let content = '';
        for (let index = 0; index < editor.selections.length; index++) {
            const selection = editor.selections[index];
            try {
                property = Property_1.default.fromEditorPosition(editor, selection.active);
            }
            catch (error) {
                this.showErrorMessage(error.message);
                return null;
            }
            content += this.setterTemplate(property);
        }
        this.renderTemplate(content);
    }
    getterTemplate(prop) {
        const name = prop.getName();
        const description = prop.getDescription();
        const tab = prop.getIndentation();
        const type = prop.getType();
        const spacesAfterReturn = Array(this.config.getInt('spacesAfterReturn', 2) + 1).join(' ');
        const templateFile = this.config.get('getterTemplate', 'getter.js');
        if (this.templatesManager.exists(templateFile)) {
            const template = require(this.templatesManager.path(templateFile));
            return template(prop);
        }
        return (`\n`
            + tab + `public function ` + prop.getterName() + `()\n`
            + tab + `{\n`
            + tab + tab + `return $this->` + name + `;\n`
            + tab + `}\n`);
    }
    setterTemplate(prop) {
        const name = prop.getName();
        const description = prop.getDescription();
        const tab = prop.getIndentation();
        const type = prop.getType();
        const typeHint = prop.getTypeHint();
        const spacesAfterParam = Array(this.config.getInt('spacesAfterParam', 2) + 1).join(' ');
        const spacesAfterParamVar = Array(this.config.getInt('spacesAfterParamVar', 2) + 1).join(' ');
        const spacesAfterReturn = Array(this.config.getInt('spacesAfterReturn', 2) + 1).join(' ');
        const templateFile = this.config.get('setterTemplate', 'setter.js');
        const name2 = (name.charAt(0)=="_")? name.substring(1):name;
		if (this.templatesManager.exists(templateFile)) {
            const template = require(this.templatesManager.path(templateFile));
            return template(prop);
        }
		
        return (`\n`
            + tab + `public function ` + prop.setterName() + `(` + (typeHint ? typeHint + ` ` : ``) + `$` + name2 + `)\n`
            + tab + `{\n`
            + tab + tab + `$this->` + name + ` = $` + name2 + `;\n`
            + tab + `}\n`);
    }
    renderTemplate(template) {
        if (!template) {
            this.showErrorMessage('Missing template to render.');
            return;
        }
        let insertLine = this.insertLine();
        if (!insertLine) {
            this.showErrorMessage('Unable to detect insert line for template.');
            return;
        }
        const editor = this.activeEditor();
        let resolver = this;
        editor.edit(function (edit) {
            edit.replace(new vscode.Position(insertLine.lineNumber, 0), template);
        }).then(success => {
            if (resolver.isRedirectEnabled() && success) {
                const redirector = new Redirector_1.default(editor);
                redirector.goToLine(this.closingClassLine().lineNumber - 1);
            }
        }, error => {
            this.showErrorMessage(`Error generating functions: ` + error);
        });
    }
    insertLine() {
        return this.closingClassLine();
    }
    isRedirectEnabled() {
        return true === this.config.get('redirect', true);
    }
    showErrorMessage(message) {
        message = 'phpGettersSetters error: ' + message.replace(/\$\(.+?\)\s\s/, '');
        vscode.window.showErrorMessage(message);
    }
    showInformationMessage(message) {
        message = 'phpGettersSetters info: ' + message.replace(/\$\(.+?\)\s\s/, '');
        vscode.window.showInformationMessage(message);
    }
}
exports.default = Resolver;
//# sourceMappingURL=Resolver.js.map