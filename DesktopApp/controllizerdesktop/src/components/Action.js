import React from 'react'

import ItemTypes from './ItemTypes'

import {useDrop} from 'react-dnd'

export default function Action(props) {

    const [{isOver, canDrop},drop]=useDrop({
        accept: ItemTypes.ACTION
    })

    return (
        <div ref={drop}></div>
    )
}