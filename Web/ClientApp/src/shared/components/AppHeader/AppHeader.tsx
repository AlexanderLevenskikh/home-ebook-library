import React from 'react';
import { FC } from 'react';
import styles from './styles.less';
import { Heading } from 'evergreen-ui';

export const AppHeader: FC = () => {
    return (
        <header className={styles.header}>
            <Heading size={800} marginTop={20}>
                TODO List
            </Heading>
        </header>
    );
};
