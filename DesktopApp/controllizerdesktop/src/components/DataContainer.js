import { useReducer } from 'react'

import { createContainer } from 'react-tracked'

const useValue = ({ reducer, initialState }) => useReducer(reducer, initialState)

const { Provider, useTracked } = createContainer(useValue)

const initialState = {
    port: '', tab: 0,
    selectedItem: null
}

const reducer = (state, action) => {
    switch (action.type) {
        case 'updatePort': return { ...state, port: action.port }
        case 'tab': return { ...state, tab: action.tab }
        case 'item': return { ...state, selectedItem: action.item }
        default: throw new Error("Unknown action type: " + action.type)
    }
}

export {
    Provider, useTracked, initialState, reducer
}