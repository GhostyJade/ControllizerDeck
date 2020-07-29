import React from 'react'

import PushButtonIcon from '../resources/pushbutton.png'
import { useTracked } from './DataContainer'

function Row({ children }) {
    return (
        <div>
            {children}
        </div>
    )
}

function PushButton({ children, onPress }) {
    return (<img onClick={onPress} src={PushButtonIcon} alt="btnIcon"></img>)
}

export default function HardwareDrawer(props) {

    const [, dispatch] = useTracked()

    const pushButton = []
    if (Object.keys(props.data).length !== 0) {
        for (const button of props.data.PushButtons) {
            pushButton.push(button)
        }
    }

    const performPressAction = (data) => {
        dispatch({ type: 'item', item: data })
    }

    return (
        <Row>
            {pushButton.map((e, i) => {
                return <PushButton setter={props.setter} onPress={() => performPressAction(e)} key={"btn" + i} />
            })}
        </Row>
    )
}