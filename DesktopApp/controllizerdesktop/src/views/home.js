import React from 'react'

import { DndProvider } from 'react-dnd'
import Backend from 'react-dnd-html5-backend'

export default function Home(props) {

    return (
        <>
            abc
            <DndProvider backend={Backend}>

            </DndProvider>
            {
                // <MenuBar open={open} handleDrawerOpen={handleDrawerOpen} handleDrawerClose={handleDrawerClose} />
            }
        </>
    )
}