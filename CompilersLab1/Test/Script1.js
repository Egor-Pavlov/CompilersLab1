let arr = [];
var speed;

var SortInProgress = false;

// ����� �������� ������� � �����������
function CheckChanged() {
    var check = document.getElementById('check');
    var textarea = document.getElementById("text");
    var spinbox = document.getElementById('sizespin');

    textarea.disabled = check.checked;
    spinbox.disabled = !(check.checked);
}

// �� �������
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function ReDraw(end = false, search = false, index = 0) {

    var chart = document.getElementById('Visualization');
    var ctx = chart.getContext('2d');

    // ������������� ���������� ������ 
    chart.height = chart.clientHeight;
    chart.width = chart.clientWidth;

    // ������� �������
    ctx.clearRect(0, 0, chart.clientWidth, chart.clientHeight);

    // ���������� ���� � ������������ ��� ������� ������ � ������
    var step  = cha  rt.clientWidth / arr.length;
    var coeff = Math.max.apply(null, arr) / chart.clientHeight;

    // ������������� ����
    var color;
    if (!end)
        color = "rgb(255, 250, 240)"
    else
        color = "rgb(21, 212, 43)"

    ctx.fillStyle = color;

    // ������ ��������
    for (var i = 0; i < arr.length; i++)
        ctx.fillRect(i * step, chart.clientHeight - arr[i] / coeff, step, arr[i] / coeff);

    if (search) {
        // ����������� ���� �������
        ctx.fillStyle = "rgb(227, 39, 39)"
        ctx.fillRect(index * step, chart.clientHeight - arr[index] / coeff, step, arr[index] / coeff);
    }
}

// ������������� ���������������� �������
function shuffle(array) {
    array.sort(() => Math.random() - 0.5);
}

//�������� �������
function CreateArray() {

    if (SortInProgress) {
        alert("���������� ��� �� ���������!");
        return;
    }

    arr.length = 0;
    //������ �� �������� ������� ������� � �������� �����������
    speed = document.getElementById('speedspin').value;
    if (document.getElementById('check').checked) {
        //������ �� �������� ������� ������� � �������� �����������
        var size = document.getElementById('sizespin').value;
        //����������� ������� �������
        for (var i = 0; i < size; i++)
            arr.push(i);

        //������������� �������
        shuffle(arr);
    }
    else {
        //������ ������ ��������� �������������
        var possibleArr = document.getElementById('text').value.split(' ');

        for (let index = 0; index < possibleArr.length; index++) {
            const element = possibleArr[index];
            if (!Number.isInteger(parseInt(element))) {
                alert("������� �� �����");
                arr.length = 0;
                return;
            }
            arr.push(parseInt(element));
        }
    }
    // ������ ������
    ReDraw(false, false);
}

async function ChooseSort() {
    //����� ������� ���������� � ����������� �� ���������� ���������
    var selected = document.getElementById('sortcombo').value;
    switch (selected) {
        case 'Heap': // ������������� ����������
            await HeapSort();
            break;
        case 'Bubble': // ����������� ����������
            await BubbleSort();
            break;
        case 'Insert': // ���������� ��������
            await InsertionSort();
            break;
        case 'Shell': // ���������� �����
            await ShellSort();
            break;
        case 'Gnome'://������ ����������
            await GnomeSort();
            break;
        case 'Cocktail'://�������������
            await CocktailSort();
            break;
        case 'Choose':// �������
            await ChoosSort();
            break;
    }
}

async function Sort() {
    if (arr.length == 0) {
        //����� �����  ������� ����������
        CreateArray();
        await sleep(1000);
    }

    if (SortInProgress) {
        alert("���������� ��� �� ���������!");
        return;
    }
    else if (arr.length == 0) {
        alert("������ �� �����! ������� ���, ��� �������� �������������� ����������!");
        return;
    }

    SortInProgress = true;

    await ChooseSort();
    ReDraw(true, false); // ������ ����� ���������� �����������
    arr.length = 0; //�������� ������
    SortInProgress = false;
}


async function Search() {
    var value = document.getElementById('value').value;
    document.getElementById("Out").value = "";
    if (arr.length == 0) {
        //����� �����  ������� ����������
        CreateArray();
        await sleep(1000);
    }
    if (SortInProgress) {
        alert("���������� ��� �� ���������!");
        return;
    }
    else if (arr.length == 0) {
        alert("������ �� �����! ������� ���, ��� �������� �������������� ����������!");
        return;
    }
    else if (value.length == 0) {
        alert("�� ������� ����� ��� ������");
        return;
    }

    SortInProgress = true;

    var found;
    var selected = document.getElementById('searchcombo').value;

    switch (selected) {
        case 'Line': // �������� �����
            found = await linearSearch(parseInt(value));
            break;
        case 'Bin': // �������� �����
            await ChooseSort();
            found = await binarySearch(parseInt(value));
            break;
    }

    SortInProgress = false;

    if (found != -1) {
        ReDraw(true, true, found);
        document.getElementById("Out").value = "������� ����� ����� ������ " + found;
    }
    else document.getElementById("Out").value = "������� ����� ����������� � �������";
    arr.length = 0;
}




//������ ���� ����������

async function SelectionSort() {
    var n = arr.length;
    for (var i = 0; i < n - 1; i++) {
        var min = i;
        for (var j = i + 1; j < n; j++) {
            if (arr[j] < arr[min])
                min = j;
        }
        var t = arr[min];
        arr[min] = arr[i];
        arr[i] = t;

        await sleep(speed * 1000);
        ReDraw(false, false);
    }
}

async function BubbleSort() {
    var n = arr.length;
    for (var i = 0; i < n - 1; i++) {
        for (var j = 0; j < n - 1 - i; j++) {
            if (arr[j + 1] < arr[j]) {
                var t = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = t;

                await sleep(speed * 1000);
                ReDraw(false, false);
            }
        }
    }
}

async function HeapSort() {
    var n = arr.length, i = Math.floor(n / 2), j, k, t;
    while (true) {
        if (i > 0)
            t = arr[--i];
        else {
            n--;
            if (n == 0)
                return;
            t = arr[n];
            arr[n] = arr[0];

            await sleep(speed * 1000);
            ReDraw(false, false);
        }

        j = i;
        k = j * 2 + 1;

        while (k < n) {
            if (k + 1 < n && arr[k + 1] > arr[k])
                k++;

            if (arr[k] > t) {
                arr[j] = arr[k];

                await sleep(speed * 1000);
                ReDraw(false, false);
                j = k;
                k = j * 2 + 1;
            }
            else break;
        }

        arr[j] = t;

        await sleep(speed * 1000);
        ReDraw(false, false);
    }
}

async function InsertionSort() {
    var n = arr.length;
    for (var i = 0; i < n; i++) {
        var v = arr[i],
            j = i - 1;
        while (j >= 0 && arr[j] > v) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = v;

        await sleep(speed * 1000);
        ReDraw(false, false);
    }
}

async function ChoosSort() {
    var UnsortedSize = arr.length;
    while (UnsortedSize > 0) {
        var Max = arr[0];
        var MaxInd = 0;
        for (var i = 0; i < UnsortedSize; i++) {
            if (Max < arr[i]) {
                Max = arr[i];
                MaxInd = i;
            }
        }

        var temp = arr[UnsortedSize - 1];
        arr[UnsortedSize - 1] = arr[MaxInd];
        arr[MaxInd] = temp;
        --UnsortedSize;

        await sleep(speed * 1000);
        ReDraw(false, false);
    }
}

async function ShellSort() {
    var n = arr.length, i = Math.floor(n / 2);
    while (i > 0) {
        for (var j = 0; j < n; j++) {
            var k = j, t = arr[j];
            while (k >= i && arr[k - i] > t) {
                arr[k] = arr[k - i];
                k -= i;

                await sleep(speed * 1000);
                ReDraw(false, false);
            }
            arr[k] = t;

            await sleep(speed * 1000);
            ReDraw(false, false);
        }
        i = (i == 2) ? 1 : Math.floor(i * 5 / 11);
    }
}
async function GnomeSort() {
    var n = arr.length, i = 1, j = 2;
    while (i < n) {
        if (arr[i - 1] < arr[i]) {
            i = j;
            j++;
        }
        else {
            var t = arr[i - 1];
            arr[i - 1] = arr[i];
            arr[i] = t;
            i--;

            await sleep(speed * 1000);
            ReDraw(false, false);

            if (i == 0) {
                i = j;
                j++;
            }
        }
    }
}

async function CocktailSort() {
    var i = 0, j = arr.length - 1, s = true, t;
    while (i < j && s) {
        s = false;
        for (var k = i; k < j; k++) {
            if (arr[k] > arr[k + 1]) {
                t = arr[k];
                arr[k] = arr[k + 1];
                arr[k + 1] = t;
                s = true;

                await sleep(speed * 1000);
                ReDraw(false, false);
            }
        }
        j--;
        if (s) {
            s = false;
            for (var k = j; k > i; k--) {
                if (arr[k] < arr[k - 1]) {
                    t = arr[k];
                    arr[k] = arr[k - 1];
                    arr[k - 1] = t;
                    s = true;

                    await sleep(speed * 1000);
                    ReDraw(false, false);
                }
            }
        }
        i++;
    }
}


//��������� ������
async function linearSearch(value) {
    let found = false;
    let position = -1;
    let index = 0;

    while (!found && index < arr.length) {
        await sleep(speed * 1000);
        ReDraw(false, true, index);

        if (arr[index] == value) {
            found = true;
            position = index;
        }
        else {
            index += 1;
        }
    }
    return position;
}

async function binarySearch(value) {
    let first = 0;    //left endpoint
    let last = arr.length - 1;   //right endpoint
    let position = -1;
    let found = false;
    let middle;

    while (found === false && first <= last) {

        middle = Math.floor((first + last) / 2);

        ReDraw(false, true, middle);
        await sleep(speed * 12000);

        if (arr[middle] == value) {
            found = true;
            position = middle;
        }
        else if (arr[middle] > value) {  //if in lower half
            last = middle - 1;
        }
        else {  //in in upper half
            first = middle + 1;
        }
    }
    return position;
}