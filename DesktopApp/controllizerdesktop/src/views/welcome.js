import React from 'react'
import PageOne from './welcome/pageone'
import PageTwo from './welcome/pagetwo'
import PageButtonProperties from './welcome/buttonconfig'

export default function Welcome() {
    const [state, setState] = React.useState({ page: 2, btnCount: 0, encodersCount: 0, knobsCount: 0, buttons: { matrix: false, w: 0, h: 0 } })
    const [buttons, setButtons] = React.useState({ matrix: false })

    if (state.page === 0)
        return <PageOne state={state} update={setState} />
    else if (state.page === 1)
        return <PageTwo state={state} update={setState} />
    else if (state.page === 2)
        return <PageButtonProperties buttons={buttons} setButtonsData={setButtons} state={state} update={setState} />
    return (
        <div>
            Error. Configuration page '{state.page}' is not valid.
        </div>
    )
}