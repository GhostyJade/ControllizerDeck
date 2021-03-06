const electron = require('electron');
// Module to control application life.
const app = electron.app;
// Module to create native browser window.
const BrowserWindow = electron.BrowserWindow;

const path = require('path');
const url = require('url');
const ipcMain = electron.ipcMain;

const isDev = require('electron-is-dev')

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mainWindow
let appTrayIcon

function createWindow() {
    // Create the browser window.
    mainWindow = new BrowserWindow({ width: 800, height: 600, show: false, webPreferences: { webSecurity: false, nodeIntegration: true, preload: __dirname + "/preload.js" } })

    // and load the index.html of the app.
    const startURL = isDev ? "http://localhost:3000/home" : url.format({
        pathname: path.join(__dirname, '../build/index.html'),
        protocol: 'file:',
        slashes: true
    })
    mainWindow.loadURL(startURL);

    // Open the DevTools.
    //mainWindow.webContents.openDevTools();

    // Emitted when the window is closed.
    mainWindow.on('closed', function () {
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        mainWindow = null
    })
    mainWindow.once('ready-to-show', () => { mainWindow.show() })
}

function createTrayIcon() {
    appTrayIcon = new electron.Tray(path.join(__dirname, '../public/logo192.png'))
    appTrayIcon.setToolTip('Controllizer Deck')
    const contextMenu = electron.Menu.buildFromTemplate([
        { label: 'Open', type: 'normal', click: () => { if (mainWindow === null) createWindow() } },
        {
            label: 'Kill daemon', type: 'normal', click: () => {
                fetch("http://localhost:8080/exit/", { method: 'POST' })
                    .then(response => response.json())
            }
        },
        { label: 'Close', type: 'normal', click: app.quit }
    ])
    appTrayIcon.setContextMenu(contextMenu)
}

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.on('ready', function () {
    createTrayIcon()
    createWindow()
});

// Quit when all windows are closed.
app.on('window-all-closed', function () {
    // On OS X it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    /*if (process.platform !== 'darwin') {
      app.quit()
    }*/
});

app.on('activate', function () {
    // On OS X it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if (mainWindow === null) {
        createWindow()
    }
});

// Used to quit from the render process, invoked after closing the daemon.
ipcMain.on('exit', (event, args) => { app.exit() })