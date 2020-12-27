import React, { useEffect } from 'react';
import PropTypes from 'prop-types';

import PushButtonIcon from '../resources/pushbutton.png';
import { useTracked } from './DataContainer';

import { HardwareDrawerStyles } from '../utils/styles';

function Row({ children, style }) {
    return (
        <div style={style}>
            {children}
        </div>
    );
}

Row.propTypes = {
    children: PropTypes.node,
    style: PropTypes.object
};

function PushButton({ onPress }) {
    return (<img onClick={onPress} src={PushButtonIcon} alt="btnIcon"></img>);
}

PushButton.propTypes = {
    onPress: PropTypes.func
};

export default function HardwareDrawer(props) {
    const [, dispatch] = useTracked();
    const [pushButtons, setPushButtons] = React.useState([]);

    useEffect(() => {
        const pushButton = [];
        if (!props.data) return;
        if (Object.keys(props.data).length !== 0) {
            for (const button of props.data.PushButtons) {
                pushButton.push(button);
            }
        }
        setPushButtons(pushButton);
    }, [props.data]);

    const performPressAction = (data) => {
        dispatch({ type: 'item', item: data });
    };
    let rows = [];

    if (props.data && props.data.HasInitializedAsMatrix) {
        const dimensions = props.data.MatrixLayout.split('x');
        const w = parseInt(dimensions[0]);
        const h = parseInt(dimensions[1]);

        let prevValue = 0;
        let currValue = w;

        for (let y = 0; y < h; y++) {
            rows.push(
                <Row style={{ height: 128 }} key={y}>
                    {pushButtons.slice(prevValue, currValue).map((e, i) => {
                        return <PushButton onPress={() => performPressAction(e)} key={'btn' + i} />;
                    })}
                </Row>
            );
            prevValue = currValue;
            currValue += w;
        }
    } else if (props.data) {
        for (let i = 0; i < pushButtons.length; i++) {
            const e = pushButtons[i];
            rows.push(
                <PushButton onPress={() => performPressAction(e)} key={'btn' + i} />
            );
        }
    }

    return (
        <div style={HardwareDrawerStyles.container}>
            {rows}
        </div>
    );
}

HardwareDrawer.propTypes = {
    data: PropTypes.object,
    setter: PropTypes.func
};
