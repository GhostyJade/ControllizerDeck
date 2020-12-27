const { dialog, shell } = require("electron").remote;

window.ipcRenderer = require("electron").ipcRenderer;
window.dialog = dialog;
window.shell = shell;
