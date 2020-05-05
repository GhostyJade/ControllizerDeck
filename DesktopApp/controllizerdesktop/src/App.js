import React from 'react';
import MenuBar from './components/menubar';

function App() {

  const [open, setOpen] = React.useState(false);

  const handleDrawerOpen = () => {
    setOpen(true)
  }

  const handleDrawerClose = () => {
    setOpen(false)
  }

  return (
    <div className="App">
      <MenuBar open={open} handleDrawerOpen={handleDrawerOpen} handleDrawerClose={handleDrawerClose} />
    </div>
  );
}

export default App;
