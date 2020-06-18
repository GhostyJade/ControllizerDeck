const electron = require('electron')
// Module to create native browser window.
const BrowserWindow = electron.BrowserWindow;

const path = require('path');
const url = require('url');

let settingWindow = null

const createSettingWindow = () => {
    if (settingWindow !== null) return;
    settingWindow = new BrowserWindow({ width: 400, height: 500, show: false, webPreferences: { webSecurity: false, nodeIntegration: true, preload: __dirname + "/../preload.js" } })

    // and load the index.html of the app.
    const startURL = "http://localhost:3000/?settings" || url.format({
        pathname: path.join(__dirname, '/../build/index.html/?settings'),
        protocol: 'file:',
        slashes: true
    })
    settingWindow.loadURL(startURL);

    settingWindow.on('closed', () => { settingWindow = null })
    settingWindow.once('ready-to-show', () => { settingWindow.show() })
}

module.exports = { createSettingWindow }


