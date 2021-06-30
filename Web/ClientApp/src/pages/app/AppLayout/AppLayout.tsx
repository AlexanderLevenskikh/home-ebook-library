import React from 'react';
import { FC } from 'react';
import { AppHeader } from 'root/pages/app/AppHeader/AppHeader';
import styles from './styles.less';

export const AppLayout: FC = ({ children }) => {
    return (
        <main className={styles.wrapper}>
            <AppHeader />
            <section className={styles.content}>{children}</section>
        </main>
    );
};
