import React from 'react'

import MenuBar from '../components/menubar'

import { DndProvider } from 'react-dnd'
import Backend from 'react-dnd-html5-backend'

export default function Home(props) {

    const [open, setOpen] = React.useState(false)

    const handleDrawerOpen = () => {
        setOpen(true)
    }

    const handleDrawerClose = () => {
        setOpen(false)
    }

    return (
        <>
            <DndProvider backend={Backend}>

            </DndProvider>
            <MenuBar open={open} handleDrawerOpen={handleDrawerOpen} handleDrawerClose={handleDrawerClose} />
        </>
    )
}