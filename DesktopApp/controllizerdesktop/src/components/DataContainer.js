import React, { useReducer } from 'react'

import { createContainer } from 'react-tracked'

const useValue = ({ reducer, initialState }) => useReducer(reducer, initialState)

const {Provider, useTracked} = createContainer(useValue)

const initialState = {
    port: ''
}

const reducer = (state, action) => {
    switch (action.type) {
        case 'updatePort': return { ...state, port: action.port }
        default: throw new Error("Unknown action type: " + action.type)
    }
}

export {
    Provider, useTracked, initialState, reducer
}