import React from 'react'
import PageOne from './welcome/pageone'
import PageTwo from './welcome/pagetwo'
import PageButtonProperties from './welcome/buttonconfig'
import PageRotaryEncoders from './welcome/encoderconfig'
import PageSerialConfig from './welcome/serialconfig'
import { useTranslation } from 'react-i18next'

export default function Welcome(props) {
    const { t } = useTranslation();
    const [state, setState] = React.useState({ page: 0, btnCount: 0, encodersCount: 0, knobsCount: 0, buttons: { matrix: false, w: 0, h: 0 }, serialPort: '' })

    if (state.page === 0)
        return <PageOne state={state} update={setState} />
    else if (state.page === 1)
        return <PageTwo state={state} update={setState} />
    else if (state.page === 2)
        return <PageSerialConfig state={state} update={setState} />
    else if (state.page === 3)
        return <PageButtonProperties state={state} update={setState} />
    else if (state.page === 5)
        return <PageRotaryEncoders state={state} update={setState} end={props.end} />
    //Display "Error. Configuration page #n is not valid.":
    return (
        <div style={{ color: 'white' }}>
            {`${t('WELCOME_ERROR_1')} '${state.page}' ${t('WELCOME_ERROR_2')}`}
        </div>
    )
}