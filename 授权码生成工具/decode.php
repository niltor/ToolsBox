<?php


function fromCode($str)
{
    $base = '';
    for ($i = 0; $i < strlen($str); $i = $i + 2) {
        # code...
        $hex = $str[$i] . $str[$i + 1];
        $ascii = chr(hexdec('0x' . $hex));
        $base .= $ascii;
    }
    return $base;
}


$str = "3630";
echo fromCode($str);
