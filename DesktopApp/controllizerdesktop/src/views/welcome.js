import React from 'react'
import PageOne from './welcome/pageone'
import PageTwo from './welcome/pagetwo'
import PageButtonProperties from './welcome/buttonconfig'
import PageRotaryEncoders from './welcome/encoderconfig'
import PageSerialConfig from './welcome/serialconfig'

export default function Welcome(props) {
    const [state, setState] = React.useState({ page: 0, btnCount: 0, encodersCount: 0, knobsCount: 0, buttons: { matrix: false, w: 0, h: 0 }, serialPort: '' })

    if (state.page === 0)
        return <PageOne state={state} update={setState} />
    else if (state.page === 1)
        return <PageTwo state={state} update={setState} />
    else if(state.page === 2)
        return <PageSerialConfig state={state} update={setState} />
    else if (state.page === 3)
        return <PageButtonProperties state={state} update={setState} />
    else if (state.page === 5)
        return <PageRotaryEncoders state={state} update={setState} end={props.end} />
    return (
        <div style={{color: 'white'}}>
            Error. Configuration page '{state.page}' is not valid.
        </div>
    )
}