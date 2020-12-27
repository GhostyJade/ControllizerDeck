import React from 'react';
import PropTypes from 'prop-types';
import PageOne from './welcome/pageone';
import PageTwo from './welcome/pagetwo';
import PageButtonProperties from './welcome/buttonconfig';
import PageRotaryEncoders from './welcome/encoderconfig';
import PageConnectionConfig from './welcome/connectionconfig';
import PageConnectivityConfig from './welcome/connectivityconfig';
import { useTranslation } from 'react-i18next';


const InitialPage = 0;
const HardwareComponentsConfig = 1;
const ConnectionConfig = 2;
const ConnectivityParams = 3;
const ButtonsProperties = 4;
const EncodersProperties = 5;

export default function Welcome(props) {
    const { t } = useTranslation();
    const [state, setState] = React.useState({ page: 0, btnCount: 0, encodersCount: 0, knobsCount: 0, buttons: { matrix: false, w: 0, h: 0 }, serialPort: '', wifiPort: '' });
    const [connectionMethod, setConnectionMethod] = React.useState(null);

    switch (state.page) {
    case InitialPage:
        return <PageOne state={state} update={setState} />;
    case HardwareComponentsConfig:
        return <PageTwo state={state} update={setState} />;
    case ConnectionConfig:
        return <PageConnectionConfig state={state} update={setState} connectionMethod={connectionMethod} setConnectionMethod={setConnectionMethod} />;
    case ConnectivityParams:
        return <PageConnectivityConfig state={state} update={setState} connectionMethod={connectionMethod} />;
    case ButtonsProperties:
        return <PageButtonProperties state={state} update={setState} />;
    case EncodersProperties:
        return <PageRotaryEncoders state={state} update={setState} end={props.end} />;
    default:
        //Display "Error. Configuration page #n is not valid.":
        return (
            <div style={{ color: 'white' }}>
                {`${t('WELCOME_ERROR_1')} '${state.page}' ${t('WELCOME_ERROR_2')}`}
            </div>
        );
    }
}

Welcome.propTypes = {
    end: PropTypes.func
};
