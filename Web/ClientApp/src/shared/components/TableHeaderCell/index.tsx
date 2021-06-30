import React, { FC } from 'react';
import styles from './styles.less';

interface IProps {}

export const TableHeaderCell: FC<IProps> = ({ children }) => {
    return <th className={styles.cell}>{children}</th>;
};
