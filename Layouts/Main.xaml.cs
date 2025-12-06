using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace praktika13.Layouts
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;

        public List<Dish> dishs = new List<Dish>();

        public Main(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;

            Dish newDish = new Dish();
            newDish.img = "img-1";
            newDish.name = "Сливочная";
            newDish.description = "Пицца - итальянское нациоальное блюдо в виде курглой открытой дрожжевой лепёшки";

            Dish.Ingredient newIngredient = new Dish.Ingredient();
            newIngredient.name = "соус «Кунжутный»";
            newDish.ingredients.Add(newIngredient);

            newIngredient = new Dish.Ingredient();
            newIngredient.name = "сыр «Моцарелла»";
            newDish.ingredients.Add(newIngredient);

            newIngredient = new Dish.Ingredient();
            newIngredient.name = "сыр «Моцарелла» мягкий";
            newDish.ingredients.Add(newIngredient);

            newIngredient = new Dish.Ingredient();
            newIngredient.name = "помидоры";
            newDish.ingredients.Add(newIngredient);


            Dish.Sizes newSize = new Dish.Sizes();
            newSize.size = 23;
            newSize.price = 380;
            newSize.wes = 530;
            newDish.sizes.Add(newSize);

            newSize = new Dish.Sizes();
            newSize.size = 30;
            newSize.price = 760;
            newSize.wes = 560;
            newDish.sizes.Add(newSize);

            newSize = new Dish.Sizes();
            newSize.size = 40;
            newSize.price = 1210;
            newSize.wes = 730;
            newDish.sizes.Add(newSize);

            dishs.Add(newDish);
            CreatePizza();
        }

        public void CreatePizza()
        {
            for (int i = 0; i < dishs.Count; i++) // перебираем пиццы
            {
                var bc = new BrushConverter(); // создаём элемент Grid

                Grid global = new Grid(); // создаём элемент Grid
                global.Height = 100; // указываем высоту
                global.Background = (Brush)bc.ConvertFrom("#ffececec"); // указываем цвет
                if (i == 0) global.Margin = new Thickness(0, 10, 0, 0); // задаём отступы

                Image logo = new Image();
                if (File.Exists(mainWindow.localPath + @"\image\dish\" + dishs[i].img + ".png")) // проверяем существует ли файл
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\dish\" + dishs[i].img + ".png")); // указываем картинку
                else
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\icon.png")); // указываем картинку

                logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; // задаём привязку по горизонтали
                logo.Height = 50; // уст. высоту
                logo.Margin = new Thickness(10, 10, 0, -10); // устанавливаем отступы
                logo.VerticalAlignment = System.Windows.VerticalAlignment.Top; // устанавливаем привязку по вертикали
                logo.Width = 50; // уст. ширину
                global.Children.Add(logo); // добавляем элемент в grid

                Label name = new Label(); // создаём текст
                name.Content = dishs[i].name; // устанавливаем наименование
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                name.Margin = new Thickness(65, 0, 0, 0);
                name.FontWeight = FontWeights.Bold;
                global.Children.Add(name);

                Label description = new Label(); // создаём текст
                description.Content = dishs[i].description; // уст. описание
                description.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                description.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                description.Margin = new Thickness(65, 20, 0, 0);
                global.Children.Add(description);

                if (dishs[i].ingredients.Count != 0) // если ингердиенты блюда суетсвуют
                {
                    Label ingredient = new Label(); // создаём текст
                    string str_ingredient = "";
                    for (int j = 0; j < dishs[i].ingredients.Count; j++) // перебираем ингредиенты
                    {
                        str_ingredient += dishs[i].ingredients[i].name; // запоминаем наименование ингредиаента
                        if (j != dishs[i].ingredients.Count - 1) // если это не последний ингредиаент
                            str_ingredient += ", ";
                    }

                    ingredient.Content = "Состав: " + str_ingredient; // устанавливаем описание ингредиентов
                    ingredient.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ingredient.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ingredient.Margin = new Thickness(65, 40, 0, 0);
                    global.Children.Add(ingredient);
                }

                Label price = new Label();
                price.Content = "Цена: " + dishs[i].sizes[0].price + " р. ";
                price.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                price.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                price.Margin = new Thickness(65, 0, 0, 10);
                global.Children.Add(price);

                Label wes = new Label();
                wes.Content = "Вес: " + dishs[i].sizes[0].wes + " г. ";
                wes.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                wes.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                wes.Margin = new Thickness(236, 0, 0, 10);
                global.Children.Add(wes);

                Button button1 = new Button();
                Button button2 = new Button();
                Button button3 = new Button();

                // низ
                Button minus = new Button();
                TextBox count = new TextBox();
                Button plus = new Button();
                CheckBox order = new CheckBox();

                button1.Content = dishs[i].sizes[0].size + " см.";
                button1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button1.Margin = new Thickness(0, 10, 110, 0);
                button1.Width = 45;
                button1.Background = Brushes.White;
                button1.Foreground = (Brush)bc.ConvertFrom("#ffdd3333"); // уст. цвет текста
                button1.Tag = i; // запоминаем id элемента в тэш
                button1.Click += delegate // назначем действие
                {
                    price.Content = "Цена: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].price + " р. "; // обновляем цену
                    wes.Content = "Вес: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].wes + " г. "; // обновляем вес
                    button1.Background = Brushes.White; // изменяем цвет
                    button1.Foreground = (Brush)bc.ConvertFrom("#ffdd3333");

                    button2.Background = (Brush)bc.ConvertFrom("#ffdd3333");
                    button2.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#ffdd3333");
                    button3.Foreground = Brushes.White;

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 0; // запоминаем активный размер
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[0].countOrder.ToString(); // изменяем стоимость блюда
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[0].orders; // снимаем галочку выбора блюда
                };
                global.Children.Add(button1);

                button2.Content = dishs[i].sizes[1].size + " см. ";
                button2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button2.Margin = new Thickness(0, 10, 60, 0);
                button2.Width = 45;
                button2.Tag = i;
                button2.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button2.Tag.ToString())].sizes[1].price + " р. ";
                    wes.Content = "Вес: " + dishs[int.Parse(button2.Tag.ToString())].sizes[1].wes + " г. ";
                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#ffdd3333");

                    button1.Background = (Brush)bc.ConvertFrom("#ffdd3333");
                    button1.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#ffdd3333");
                    button3.Foreground = Brushes.White;

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 1; // запоминаем активный размер
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[1].countOrder.ToString(); // изменяем стоимость блюда
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[1].orders; // снимаем галочку выбора блюда
                };
                global.Children.Add(button2);

                button3.Content = dishs[i].sizes[2].size + " см. ";
                button3.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button3.Margin = new Thickness(0, 10, 10, 0);
                button3.Width = 45;
                button3.Tag = i;
                button3.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button3.Tag.ToString())].sizes[2].price + " р. ";
                    wes.Content = "Вес: " + dishs[int.Parse(button3.Tag.ToString())].sizes[2].wes + " г. ";
                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#ffdd3333");

                    button1.Background = (Brush)bc.ConvertFrom("#ffdd3333");
                    button1.Foreground = Brushes.White;
                    button2.Background = (Brush)bc.ConvertFrom("#ffdd3333");
                    button2.Foreground = Brushes.White;

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 2; // запоминаем активный размер
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[2].countOrder.ToString(); // изменяем стоимость блюда
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[2].orders; // снимаем галочку выбора блюда
                };
                global.Children.Add(button3);




                minus.Content = "-";
                minus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                minus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                minus.Margin = new System.Windows.Thickness(0, 0, 103.6f, 10);
                minus.Width = 19;
                minus.Tag = i;
                minus.Click += delegate
                {
                    if (count.Text != "") // если текст не равен пустоте
                        if (int.Parse(count.Text) > 0) // если кол-во заказанных пицц больше 0
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString(); // убавляем

                            int id = int.Parse(minus.Tag.ToString()); // преобразуем ID
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text); // уменьшаем кол-во заказанных блюд
                        }
                };
                global.Children.Add(minus);




                count.Text = "0";
                count.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                count.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                count.Margin = new System.Windows.Thickness(0, 0, 33.6f, 10);
                count.TextWrapping = TextWrapping.Wrap; // вырвниваем текст
                count.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                count.Width = 65;
                count.Height = 19;
                count.Tag = i;
                global.Children.Add(count);


                plus.Content = "+";
                plus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                plus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                plus.Margin = new System.Windows.Thickness(0, 0, 9.6f, 10);
                plus.Width = 19;
                plus.Tag = i;
                plus.Click += delegate
                {
                    if (count.Text != "") // если текст не равен пустоте
                        if (int.Parse(count.Text) < 15) // если кол-во заказанных пицц меньше 15
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString(); // прибавляем

                            int id = int.Parse(plus.Tag.ToString()); // преобразуем ID
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text); // увеличиваем кол-во заказанных блюд
                        }
                };
                global.Children.Add(plus);

                order.Content = "Выбрать";
                order.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                order.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                order.Margin = new System.Windows.Thickness(0, 0, 128, 13);
                order.Width = 19;
                order.Tag = i;
                order.Click += delegate
                {
                    int id = int.Parse(order.Tag.ToString()); // преобразуем ID
                    dishs[id].sizes[dishs[id].activeSize].orders = (bool)order.IsChecked; // увеличиваем кол-во заказанных блюд
                };
                global.Children.Add(order);

                parrent.Children.Add(global);
            }
        }
    }
}
