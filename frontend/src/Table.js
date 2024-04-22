import React from "react";
import { useState } from "react";
import { useFilters, useTable, useAsyncDebounce, useSortBy, useGlobalFilter } from "react-table";

const initialState = { hiddenColumns: ['ProjectName', 'MetroAreaStateAbr', 'MetroAreaStateName', 'Status'] };

export default function Table({ columns, data }) {
    const {
        getTableProps,
        getTableBodyProps,
        headerGroups,
        rows,
        prepareRow,
        state: { globalFilter },
        setGlobalFilter
    } = useTable(
        {
            columns,
            data,
            initialState
        },
        useGlobalFilter
    );

    const TWO_HUNDRED_MS = 200;

    const [value, setValue] = useState(globalFilter);
    
    const onChange = useAsyncDebounce(value => {
        setGlobalFilter(value || undefined)
    }, TWO_HUNDRED_MS);


return (
    <>
    <input
      value={value || ""}
      onChange={e => {
        setValue(e.target.value);
        onChange(e.target.value);
      }}
      placeholder={`Search`}
    />
    <table {...getTableProps()}>
        <thead>
            {headerGroups.map(headerGroup => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                {headerGroup.headers.map(column => (
                    <th {...column.getHeaderProps()}>{column.render("Header")}</th>
                ))}
                </tr>
            ))}
        </thead>
        <tbody {...getTableBodyProps()}>
            {rows.map((row, i) => {
                prepareRow(row);
                return (
                <tr {...row.getRowProps()}>
                    {row.cells.map(cell => {
                    return <td {...cell.getCellProps()}>{cell.render("Cell")}</td>;
                    })}
                </tr>
                );
            })}
        </tbody>
    </table>
    </>
  );
}