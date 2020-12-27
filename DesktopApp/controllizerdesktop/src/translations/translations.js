import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';

import english from './en';
import italian from './it';

i18n.use(initReactI18next).init({
    resources: {
        en: { translation: english },
        it: { translation: italian },
    },
    lng: 'en',
    fallbackLng: 'en',
});

export default i18n;
