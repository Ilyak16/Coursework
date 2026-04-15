using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Models;

public partial class KupriyanovIlya2307a1HlopokContext : DbContext
{
    public KupriyanovIlya2307a1HlopokContext()
    {
    }

    public KupriyanovIlya2307a1HlopokContext(DbContextOptions<KupriyanovIlya2307a1HlopokContext> options)
        : base(options)
    {
    }

    public virtual DbSet<АссортиментМагазина> АссортиментМагазинаs { get; set; }

    public virtual DbSet<Бригада> Бригадаs { get; set; }

    public virtual DbSet<ДвижениеЗапасов> ДвижениеЗапасовs { get; set; }

    public virtual DbSet<Заказ> Заказs { get; set; }

    public virtual DbSet<ЗакреплениеТехники> ЗакреплениеТехникиs { get; set; }

    public virtual DbSet<Запасы> Запасыs { get; set; }

    public virtual DbSet<ИспользованиеРесурсов> ИспользованиеРесурсовs { get; set; }

    public virtual DbSet<КатегорияТоваров> КатегорияТоваровs { get; set; }

    public virtual DbSet<КачествоКонтроля> КачествоКонтроляs { get; set; }

    public virtual DbSet<Кипа> Кипаs { get; set; }

    public virtual DbSet<Клиент> Клиентs { get; set; }

    public virtual DbSet<Магазин> Магазинs { get; set; }

    public virtual DbSet<Номенклатура> Номенклатураs { get; set; }

    public virtual DbSet<ПартияПряжи> ПартияПряжиs { get; set; }

    public virtual DbSet<ПартияТкани> ПартияТканиs { get; set; }

    public virtual DbSet<Перевозка> Перевозкаs { get; set; }

    public virtual DbSet<ПланРабот> ПланРаботs { get; set; }

    public virtual DbSet<Плантация> Плантацияs { get; set; }

    public virtual DbSet<ПозицияЗаказа> ПозицияЗаказаs { get; set; }

    public virtual DbSet<ПозицияЧека> ПозицияЧекаs { get; set; }

    public virtual DbSet<Поле> Полеs { get; set; }

    public virtual DbSet<Поставка> Поставкаs { get; set; }

    public virtual DbSet<Продажа> Продажаs { get; set; }

    public virtual DbSet<Рабочий> Рабочийs { get; set; }

    public virtual DbSet<Ресурс> Ресурсs { get; set; }

    public virtual DbSet<Склад> Складs { get; set; }

    public virtual DbSet<Техника> Техникаs { get; set; }

    public virtual DbSet<ТипРабот> ТипРаботs { get; set; }

    public virtual DbSet<ТипТехники> ТипТехникиs { get; set; }

    public virtual DbSet<ТипФабрики> ТипФабрикиs { get; set; }

    public virtual DbSet<Урожай> Урожайs { get; set; }

    public virtual DbSet<Фабрика> Фабрикаs { get; set; }

    public virtual DbSet<Ценообразование> Ценообразованиеs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dbsrv\\gor2025;Database=Kupriyanov_Ilya2307a1_Hlopok;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<АссортиментМагазина>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторАссортимента).HasName("PK__Ассортим__0CB2208D100D8B62");

            entity.ToTable("Ассортимент_магазина");

            entity.Property(e => e.ИдентификаторАссортимента).HasColumnName("Идентификатор_ассортимента");
            entity.Property(e => e.ИдентификаторМагазина).HasColumnName("Идентификатор_магазина");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.МаксимальноеКоличество)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Максимальное_количество");
            entity.Property(e => e.МинимальноеКоличество)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Минимальное_количество");

            entity.HasOne(d => d.ИдентификаторМагазинаNavigation).WithMany(p => p.АссортиментМагазинаs)
                .HasForeignKey(d => d.ИдентификаторМагазина)
                .HasConstraintName("FK__Ассортиме__Идент__0C85DE4D");

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.АссортиментМагазинаs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK__Ассортиме__Идент__0D7A0286");
        });

        modelBuilder.Entity<Бригада>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторБригады).HasName("PK__Бригада__E702586DC64EE541");

            entity.ToTable("Бригада");

            entity.Property(e => e.ИдентификаторБригады).HasColumnName("Идентификатор_бригады");
            entity.Property(e => e.ИдентификаторБригадира).HasColumnName("Идентификатор_бригадира");
            entity.Property(e => e.ИдентификаторПлантации).HasColumnName("Идентификатор_плантации");
            entity.Property(e => e.ТипБригады)
                .HasMaxLength(100)
                .HasColumnName("Тип_бригады");

            entity.HasOne(d => d.ИдентификаторБригадираNavigation).WithMany(p => p.Бригадаs)
                .HasForeignKey(d => d.ИдентификаторБригадира)
                .HasConstraintName("FK_Бригада_Бригадир");

            entity.HasOne(d => d.ИдентификаторПлантацииNavigation).WithMany(p => p.Бригадаs)
                .HasForeignKey(d => d.ИдентификаторПлантации)
                .HasConstraintName("FK__Бригада__Идентиф__4222D4EF");
        });

        modelBuilder.Entity<ДвижениеЗапасов>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторДвиженияЗапасов).HasName("PK__Движение__88179C22D33897DD");

            entity.ToTable("Движение_запасов");

            entity.Property(e => e.ИдентификаторДвиженияЗапасов).HasColumnName("Идентификатор_движения_запасов");
            entity.Property(e => e.ДатаПеремещения)
                .HasColumnType("datetime")
                .HasColumnName("Дата_перемещения");
            entity.Property(e => e.ИдентификаторЗапасов).HasColumnName("Идентификатор_запасов");
            entity.Property(e => e.Количество).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ТипДвижения)
                .HasMaxLength(50)
                .HasColumnName("Тип_движения");

            entity.HasOne(d => d.ИдентификаторЗапасовNavigation).WithMany(p => p.ДвижениеЗапасовs)
                .HasForeignKey(d => d.ИдентификаторЗапасов)
                .HasConstraintName("FK__Движение___Идент__7B5B524B");
        });

        modelBuilder.Entity<Заказ>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторЗаказа).HasName("PK__Заказ__A84A0095BB2D93B4");

            entity.ToTable("Заказ");

            entity.Property(e => e.ИдентификаторЗаказа).HasColumnName("Идентификатор_заказа");
            entity.Property(e => e.Дата).HasColumnType("datetime");
            entity.Property(e => e.ИдентификаторКлиента).HasColumnName("Идентификатор_клиента");
            entity.Property(e => e.ОбщаяСтоимость)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Общая_стоимость");
            entity.Property(e => e.Статус).HasMaxLength(50);

            entity.HasOne(d => d.ИдентификаторКлиентаNavigation).WithMany(p => p.Заказs)
                .HasForeignKey(d => d.ИдентификаторКлиента)
                .HasConstraintName("FK__Заказ__Идентифик__02FC7413");
        });

        modelBuilder.Entity<ЗакреплениеТехники>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторЗакрепления).HasName("PK__Закрепле__72D537F26682C12D");

            entity.ToTable("Закрепление_техники");

            entity.Property(e => e.ИдентификаторЗакрепления).HasColumnName("Идентификатор_закрепления");
            entity.Property(e => e.ДатаЗакрепления)
                .HasColumnType("datetime")
                .HasColumnName("Дата_закрепления");
            entity.Property(e => e.ДатаОткрепления)
                .HasColumnType("datetime")
                .HasColumnName("Дата_открепления");
            entity.Property(e => e.ИдентификаторПоля).HasColumnName("Идентификатор_поля");
            entity.Property(e => e.ИдентификаторТехники).HasColumnName("Идентификатор_техники");
            entity.Property(e => e.ИдентификаторФабрики).HasColumnName("Идентификатор_фабрики");

            entity.HasOne(d => d.ИдентификаторПоляNavigation).WithMany(p => p.ЗакреплениеТехникиs)
                .HasForeignKey(d => d.ИдентификаторПоля)
                .HasConstraintName("FK__Закреплен__Идент__4D94879B");

            entity.HasOne(d => d.ИдентификаторТехникиNavigation).WithMany(p => p.ЗакреплениеТехникиs)
                .HasForeignKey(d => d.ИдентификаторТехники)
                .HasConstraintName("FK__Закреплен__Идент__4CA06362");

            entity.HasOne(d => d.ИдентификаторФабрикиNavigation).WithMany(p => p.ЗакреплениеТехникиs)
                .HasForeignKey(d => d.ИдентификаторФабрики)
                .HasConstraintName("FK_Закрепление_техники_Фабрика");
        });

        modelBuilder.Entity<Запасы>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторЗапасов).HasName("PK__Запасы__AB65343E5BEF10C5");

            entity.ToTable("Запасы");

            entity.Property(e => e.ИдентификаторЗапасов).HasColumnName("Идентификатор_запасов");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.ИдентификаторПартииТкани).HasColumnName("Идентификатор_партии_ткани");
            entity.Property(e => e.ИдентификаторСклада).HasColumnName("Идентификатор_склада");
            entity.Property(e => e.Количество).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.Запасыs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK__Запасы__Идентифи__778AC167");

            entity.HasOne(d => d.ИдентификаторПартииТканиNavigation).WithMany(p => p.Запасыs)
                .HasForeignKey(d => d.ИдентификаторПартииТкани)
                .HasConstraintName("FK__Запасы__Идентифи__787EE5A0");

            entity.HasOne(d => d.ИдентификаторСкладаNavigation).WithMany(p => p.Запасыs)
                .HasForeignKey(d => d.ИдентификаторСклада)
                .HasConstraintName("FK__Запасы__Идентифи__76969D2E");
        });

        modelBuilder.Entity<ИспользованиеРесурсов>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторИспользования).HasName("PK__Использо__9B14E660F87893EF");

            entity.ToTable("Использование_ресурсов");

            entity.Property(e => e.ИдентификаторИспользования).HasColumnName("Идентификатор_использования");
            entity.Property(e => e.Дата).HasColumnType("datetime");
            entity.Property(e => e.ИдентификаторПланаРабот).HasColumnName("Идентификатор_плана_работ");
            entity.Property(e => e.ИдентификаторРесурса).HasColumnName("Идентификатор_ресурса");
            entity.Property(e => e.Количество).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ИдентификаторПланаРаботNavigation).WithMany(p => p.ИспользованиеРесурсовs)
                .HasForeignKey(d => d.ИдентификаторПланаРабот)
                .HasConstraintName("FK__Использов__Идент__534D60F1");

            entity.HasOne(d => d.ИдентификаторРесурсаNavigation).WithMany(p => p.ИспользованиеРесурсовs)
                .HasForeignKey(d => d.ИдентификаторРесурса)
                .HasConstraintName("FK__Использов__Идент__52593CB8");
        });

        modelBuilder.Entity<КатегорияТоваров>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторКатегорииТоваров).HasName("PK__Категори__2634EB7345126899");

            entity.ToTable("Категория_товаров");

            entity.Property(e => e.ИдентификаторКатегорииТоваров).HasColumnName("Идентификатор_категории_товаров");
            entity.Property(e => e.Название).HasMaxLength(200);
        });

        modelBuilder.Entity<КачествоКонтроля>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторКонтроля).HasName("PK__Качество__C7B3D5869C74D5BE");

            entity.ToTable("Качество_контроля");

            entity.Property(e => e.ИдентификаторКонтроля).HasColumnName("Идентификатор_контроля");
            entity.Property(e => e.ДатаПроверки)
                .HasColumnType("datetime")
                .HasColumnName("Дата_проверки");
            entity.Property(e => e.ИдентификаторПартииТкани).HasColumnName("Идентификатор_партии_ткани");
            entity.Property(e => e.Комментарии).HasMaxLength(500);
            entity.Property(e => e.Результат).HasMaxLength(100);
            entity.Property(e => e.ФиоИнспектора)
                .HasMaxLength(200)
                .HasColumnName("ФИО_инспектора");

            entity.HasOne(d => d.ИдентификаторПартииТканиNavigation).WithMany(p => p.КачествоКонтроляs)
                .HasForeignKey(d => d.ИдентификаторПартииТкани)
                .HasConstraintName("FK__Качество___Идент__6D0D32F4");
        });

        modelBuilder.Entity<Кипа>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторКипы).HasName("PK__Кипа__739AAEDF50B7CFA2");

            entity.ToTable("Кипа");

            entity.Property(e => e.ИдентификаторКипы).HasColumnName("Идентификатор_кипы");
            entity.Property(e => e.Вес).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ДатаПроизводства)
                .HasColumnType("datetime")
                .HasColumnName("Дата_производства");
            entity.Property(e => e.ИдентификаторУрожая).HasColumnName("Идентификатор_урожая");
            entity.Property(e => e.ИдентификаторФабрики).HasColumnName("Идентификатор_фабрики");
            entity.Property(e => e.Качество).HasMaxLength(100);

            entity.HasOne(d => d.ИдентификаторУрожаяNavigation).WithMany(p => p.Кипаs)
                .HasForeignKey(d => d.ИдентификаторУрожая)
                .HasConstraintName("FK__Кипа__Идентифика__619B8048");

            entity.HasOne(d => d.ИдентификаторФабрикиNavigation).WithMany(p => p.Кипаs)
                .HasForeignKey(d => d.ИдентификаторФабрики)
                .HasConstraintName("FK__Кипа__Идентифика__628FA481");
        });

        modelBuilder.Entity<Клиент>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторКлиента).HasName("PK__Клиент__968E17E1D0B398CF");

            entity.ToTable("Клиент");

            entity.Property(e => e.ИдентификаторКлиента).HasColumnName("Идентификатор_клиента");
            entity.Property(e => e.КонтактнаяИнформация)
                .HasMaxLength(300)
                .HasColumnName("Контактная_информация");
            entity.Property(e => e.ТипКлиента)
                .HasMaxLength(50)
                .HasColumnName("Тип_клиента");
            entity.Property(e => e.УровеньЛояльности)
                .HasMaxLength(50)
                .HasColumnName("Уровень_лояльности");
            entity.Property(e => e.ФиоИлиНазваниеКомпании)
                .HasMaxLength(300)
                .HasColumnName("ФИО_или_название_компании");
        });

        modelBuilder.Entity<Магазин>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторМагазина).HasName("PK__Магазин__CE183B4DB2308D90");

            entity.ToTable("Магазин");

            entity.Property(e => e.ИдентификаторМагазина).HasColumnName("Идентификатор_магазина");
            entity.Property(e => e.Адрес).HasMaxLength(500);
            entity.Property(e => e.ИдентификаторСклада).HasColumnName("Идентификатор_склада");
            entity.Property(e => e.Название).HasMaxLength(200);

            entity.HasOne(d => d.ИдентификаторСкладаNavigation).WithMany(p => p.Магазинs)
                .HasForeignKey(d => d.ИдентификаторСклада)
                .HasConstraintName("FK__Магазин__Идентиф__09A971A2");
        });

        modelBuilder.Entity<Номенклатура>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторНоменклатуры).HasName("PK__Номенкла__73DB4E36A1B61FD9");

            entity.ToTable("Номенклатура");

            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.Артикул).HasMaxLength(100);
            entity.Property(e => e.Единицы).HasMaxLength(50);
            entity.Property(e => e.ИдентификаторКатегорииТоваров).HasColumnName("Идентификатор_категории_товаров");
            entity.Property(e => e.Название).HasMaxLength(200);
            entity.Property(e => e.ПлановаяСтоимость)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Плановая_стоимость");

            entity.HasOne(d => d.ИдентификаторКатегорииТоваровNavigation).WithMany(p => p.Номенклатураs)
                .HasForeignKey(d => d.ИдентификаторКатегорииТоваров)
                .HasConstraintName("FK__Номенклат__Идент__71D1E811");
        });

        modelBuilder.Entity<ПартияПряжи>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПряжи).HasName("PK__Партия_п__B761D9C64BEC5586");

            entity.ToTable("Партия_пряжи");

            entity.Property(e => e.ИдентификаторПряжи).HasColumnName("Идентификатор_пряжи");
            entity.Property(e => e.ИдентификаторКипы).HasColumnName("Идентификатор_кипы");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.ИдентификаторФабрики).HasColumnName("Идентификатор_фабрики");
            entity.Property(e => e.Качество).HasMaxLength(100);
            entity.Property(e => e.ТипПряжи)
                .HasMaxLength(100)
                .HasColumnName("Тип_пряжи");

            entity.HasOne(d => d.ИдентификаторКипыNavigation).WithMany(p => p.ПартияПряжиs)
                .HasForeignKey(d => d.ИдентификаторКипы)
                .HasConstraintName("FK__Партия_пр__Идент__656C112C");

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.ПартияПряжиs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK_Партия_пряжи_Номенклатура");

            entity.HasOne(d => d.ИдентификаторФабрикиNavigation).WithMany(p => p.ПартияПряжиs)
                .HasForeignKey(d => d.ИдентификаторФабрики)
                .HasConstraintName("FK__Партия_пр__Идент__66603565");
        });

        modelBuilder.Entity<ПартияТкани>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторТкани).HasName("PK__Партия_т__DFDBF04E1637535C");

            entity.ToTable("Партия_ткани");

            entity.Property(e => e.ИдентификаторТкани).HasColumnName("Идентификатор_ткани");
            entity.Property(e => e.Вес).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.ИдентификаторПартииПряжи).HasColumnName("Идентификатор_партии_пряжи");
            entity.Property(e => e.ИдентификаторФабрики).HasColumnName("Идентификатор_фабрики");
            entity.Property(e => e.Плотность).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Статус).HasMaxLength(50);
            entity.Property(e => e.Тип).HasMaxLength(100);
            entity.Property(e => e.Цвет).HasMaxLength(100);

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.ПартияТканиs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK_Партия_ткани_Номенклатура");

            entity.HasOne(d => d.ИдентификаторПартииПряжиNavigation).WithMany(p => p.ПартияТканиs)
                .HasForeignKey(d => d.ИдентификаторПартииПряжи)
                .HasConstraintName("FK__Партия_тк__Идент__693CA210");

            entity.HasOne(d => d.ИдентификаторФабрикиNavigation).WithMany(p => p.ПартияТканиs)
                .HasForeignKey(d => d.ИдентификаторФабрики)
                .HasConstraintName("FK__Партия_тк__Идент__6A30C649");
        });

        modelBuilder.Entity<Перевозка>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПеревозки).HasName("PK__Перевозк__928C63E82D279786");

            entity.ToTable("Перевозка");

            entity.Property(e => e.ИдентификаторПеревозки).HasColumnName("Идентификатор_перевозки");
            entity.Property(e => e.ВесУрожая)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Вес_урожая");
            entity.Property(e => e.Дата).HasColumnType("datetime");
            entity.Property(e => e.ИдентификаторУрожая).HasColumnName("Идентификатор_урожая");
            entity.Property(e => e.ИдентификаторФабрики).HasColumnName("Идентификатор_фабрики");

            entity.HasOne(d => d.ИдентификаторУрожаяNavigation).WithMany(p => p.Перевозкаs)
                .HasForeignKey(d => d.ИдентификаторУрожая)
                .HasConstraintName("FK__Перевозка__Идент__5DCAEF64");

            entity.HasOne(d => d.ИдентификаторФабрикиNavigation).WithMany(p => p.Перевозкаs)
                .HasForeignKey(d => d.ИдентификаторФабрики)
                .HasConstraintName("FK__Перевозка__Идент__5EBF139D");
        });

        modelBuilder.Entity<ПланРабот>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПлана).HasName("PK__План_раб__17246E2660A7FF84");

            entity.ToTable("План_работ");

            entity.Property(e => e.ИдентификаторПлана).HasColumnName("Идентификатор_плана");
            entity.Property(e => e.ЗапланированныйКонец)
                .HasColumnType("datetime")
                .HasColumnName("Запланированный_конец");
            entity.Property(e => e.ЗапланированныйСтарт)
                .HasColumnType("datetime")
                .HasColumnName("Запланированный_старт");
            entity.Property(e => e.ИдентификаторПоля).HasColumnName("Идентификатор_поля");
            entity.Property(e => e.ИдентификаторТипаРабот).HasColumnName("Идентификатор_типа_работ");
            entity.Property(e => e.Статус).HasMaxLength(50);

            entity.HasOne(d => d.ИдентификаторПоляNavigation).WithMany(p => p.ПланРаботs)
                .HasForeignKey(d => d.ИдентификаторПоля)
                .HasConstraintName("FK__План_рабо__Идент__3F466844");

            entity.HasOne(d => d.ИдентификаторТипаРаботNavigation).WithMany(p => p.ПланРаботs)
                .HasForeignKey(d => d.ИдентификаторТипаРабот)
                .HasConstraintName("FK__План_рабо__Идент__3E52440B");
        });

        modelBuilder.Entity<Плантация>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПлантации).HasName("PK__Плантаци__70271E67E57BF87C");

            entity.ToTable("Плантация");

            entity.Property(e => e.ИдентификаторПлантации).HasColumnName("Идентификатор_плантации");
            entity.Property(e => e.Адрес).HasMaxLength(500);
            entity.Property(e => e.КонтактныеДанные)
                .HasMaxLength(300)
                .HasColumnName("Контактные_данные");
            entity.Property(e => e.Название).HasMaxLength(200);
            entity.Property(e => e.Площадь).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ПозицияЗаказа>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПозиции).HasName("PK__Позиция___76530D6994049237");

            entity.ToTable("Позиция_заказа");

            entity.Property(e => e.ИдентификаторПозиции).HasColumnName("Идентификатор_позиции");
            entity.Property(e => e.ИдентификаторЗаказа).HasColumnName("Идентификатор_заказа");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.Количество).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Скидка).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Стоимость).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ИдентификаторЗаказаNavigation).WithMany(p => p.ПозицияЗаказаs)
                .HasForeignKey(d => d.ИдентификаторЗаказа)
                .HasConstraintName("FK__Позиция_з__Идент__05D8E0BE");

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.ПозицияЗаказаs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK__Позиция_з__Идент__06CD04F7");
        });

        modelBuilder.Entity<ПозицияЧека>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПозицииЧека).HasName("PK__Позиция___F7FAF624A44601AF");

            entity.ToTable("Позиция_чека");

            entity.Property(e => e.ИдентификаторПозицииЧека).HasColumnName("Идентификатор_позиции_чека");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.ИдентификаторПродажи).HasColumnName("Идентификатор_продажи");
            entity.Property(e => e.Количество).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Цена).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.ПозицияЧекаs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK__Позиция_ч__Идент__17F790F9");

            entity.HasOne(d => d.ИдентификаторПродажиNavigation).WithMany(p => p.ПозицияЧекаs)
                .HasForeignKey(d => d.ИдентификаторПродажи)
                .HasConstraintName("FK__Позиция_ч__Идент__17036CC0");
        });

        modelBuilder.Entity<Поле>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПоля).HasName("PK__Поле__62D6E9BCF12DCE0C");

            entity.ToTable("Поле");

            entity.Property(e => e.ИдентификаторПоля).HasColumnName("Идентификатор_поля");
            entity.Property(e => e.ИдентификаторПлантации).HasColumnName("Идентификатор_плантации");
            entity.Property(e => e.Площадь).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Статус).HasMaxLength(50);
            entity.Property(e => e.ТипПочвы)
                .HasMaxLength(100)
                .HasColumnName("Тип_почвы");

            entity.HasOne(d => d.ИдентификаторПлантацииNavigation).WithMany(p => p.Полеs)
                .HasForeignKey(d => d.ИдентификаторПлантации)
                .HasConstraintName("FK__Поле__Идентифика__398D8EEE");
        });

        modelBuilder.Entity<Поставка>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПоставки).HasName("PK__Поставка__98E40504E8152C34");

            entity.ToTable("Поставка");

            entity.Property(e => e.ИдентификаторПоставки).HasColumnName("Идентификатор_поставки");
            entity.Property(e => e.Дата).HasColumnType("datetime");
            entity.Property(e => e.ДействительноеКоличествоПоставки)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Действительное_количество_поставки");
            entity.Property(e => e.ЗапланированноеКоличествоПоставки)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Запланированное_количество_поставки");
            entity.Property(e => e.ИдентификаторМагазина).HasColumnName("Идентификатор_магазина");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");

            entity.HasOne(d => d.ИдентификаторМагазинаNavigation).WithMany(p => p.Поставкаs)
                .HasForeignKey(d => d.ИдентификаторМагазина)
                .HasConstraintName("FK__Поставка__Иденти__10566F31");

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.Поставкаs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK__Поставка__Иденти__114A936A");
        });

        modelBuilder.Entity<Продажа>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторПродажи).HasName("PK__Продажа__63194CE78DFB1B16");

            entity.ToTable("Продажа");

            entity.Property(e => e.ИдентификаторПродажи).HasColumnName("Идентификатор_продажи");
            entity.Property(e => e.Дата).HasColumnType("datetime");
            entity.Property(e => e.ИдентификаторМагазина).HasColumnName("Идентификатор_магазина");
            entity.Property(e => e.ОбщаяСтоимость)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Общая_стоимость");

            entity.HasOne(d => d.ИдентификаторМагазинаNavigation).WithMany(p => p.Продажаs)
                .HasForeignKey(d => d.ИдентификаторМагазина)
                .HasConstraintName("FK__Продажа__Идентиф__14270015");
        });

        modelBuilder.Entity<Рабочий>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторРабочего).HasName("PK__Рабочий__D3D0B2E274820EF2");

            entity.ToTable("Рабочий");

            entity.Property(e => e.ИдентификаторРабочего).HasColumnName("Идентификатор_рабочего");
            entity.Property(e => e.Должность).HasMaxLength(100);
            entity.Property(e => e.ИдентификаторБригады).HasColumnName("Идентификатор_бригады");
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(50)
                .HasColumnName("Номер_телефона");
            entity.Property(e => e.Фио)
                .HasMaxLength(200)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.ИдентификаторБригадыNavigation).WithMany(p => p.Рабочийs)
                .HasForeignKey(d => d.ИдентификаторБригады)
                .HasConstraintName("FK__Рабочий__Идентиф__44FF419A");
        });

        modelBuilder.Entity<Ресурс>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторРесурса).HasName("PK__Ресурс__2E220D98C9AAA2E2");

            entity.ToTable("Ресурс");

            entity.Property(e => e.ИдентификаторРесурса).HasColumnName("Идентификатор_ресурса");
            entity.Property(e => e.Название).HasMaxLength(200);
            entity.Property(e => e.СистемаСчисления)
                .HasMaxLength(50)
                .HasColumnName("Система_счисления");
            entity.Property(e => e.ТипРесурса)
                .HasMaxLength(100)
                .HasColumnName("Тип_ресурса");
        });

        modelBuilder.Entity<Склад>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторСклада).HasName("PK__Склад__822A6BA0F9B91010");

            entity.ToTable("Склад");

            entity.Property(e => e.ИдентификаторСклада).HasColumnName("Идентификатор_склада");
            entity.Property(e => e.Адрес).HasMaxLength(500);
            entity.Property(e => e.Название).HasMaxLength(200);
            entity.Property(e => e.ТипПродукции)
                .HasMaxLength(100)
                .HasColumnName("Тип_продукции");
        });

        modelBuilder.Entity<Техника>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторТехники).HasName("PK__Техника__AD4831C77A23A84F");

            entity.ToTable("Техника");

            entity.Property(e => e.ИдентификаторТехники).HasColumnName("Идентификатор_техники");
            entity.Property(e => e.ИдентификаторТипаТехники).HasColumnName("Идентификатор_типа_техники");
            entity.Property(e => e.Модель).HasMaxLength(200);
            entity.Property(e => e.Серия).HasMaxLength(100);
            entity.Property(e => e.СрокЭксплуатации).HasColumnName("Срок_эксплуатации");
            entity.Property(e => e.Статус).HasMaxLength(50);

            entity.HasOne(d => d.ИдентификаторТипаТехникиNavigation).WithMany(p => p.Техникаs)
                .HasForeignKey(d => d.ИдентификаторТипаТехники)
                .HasConstraintName("FK__Техника__Идентиф__49C3F6B7");
        });

        modelBuilder.Entity<ТипРабот>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторТипаРабот).HasName("PK__Тип_рабо__DD055ED56622513A");

            entity.ToTable("Тип_работ");

            entity.Property(e => e.ИдентификаторТипаРабот).HasColumnName("Идентификатор_типа_работ");
            entity.Property(e => e.Название).HasMaxLength(200);
            entity.Property(e => e.Описание).HasMaxLength(500);
        });

        modelBuilder.Entity<ТипТехники>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторТипаТехники).HasName("PK__Тип_техн__36BEAF120C2765AE");

            entity.ToTable("Тип_техники");

            entity.Property(e => e.ИдентификаторТипаТехники).HasColumnName("Идентификатор_типа_техники");
            entity.Property(e => e.Категория).HasMaxLength(100);
            entity.Property(e => e.Название).HasMaxLength(200);
        });

        modelBuilder.Entity<ТипФабрики>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторТипа).HasName("PK__Тип_фабр__D51F51F6CD8A0D6F");

            entity.ToTable("Тип_фабрики");

            entity.Property(e => e.ИдентификаторТипа).HasColumnName("Идентификатор_типа");
            entity.Property(e => e.Название).HasMaxLength(200);
        });

        modelBuilder.Entity<Урожай>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторУрожая).HasName("PK__Урожай__5CAAF6F769A4481C");

            entity.ToTable("Урожай");

            entity.Property(e => e.ИдентификаторУрожая).HasColumnName("Идентификатор_урожая");
            entity.Property(e => e.ВесСырца)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Вес_сырца");
            entity.Property(e => e.ДатаЖатвы)
                .HasColumnType("datetime")
                .HasColumnName("Дата_жатвы");
            entity.Property(e => e.ИдентификаторПоля).HasColumnName("Идентификатор_поля");
            entity.Property(e => e.КачествоСырца)
                .HasMaxLength(100)
                .HasColumnName("Качество_сырца");

            entity.HasOne(d => d.ИдентификаторПоляNavigation).WithMany(p => p.Урожайs)
                .HasForeignKey(d => d.ИдентификаторПоля)
                .HasConstraintName("FK__Урожай__Идентифи__5629CD9C");
        });

        modelBuilder.Entity<Фабрика>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторФабрики).HasName("PK__Фабрика__E5974C78BB3DBB80");

            entity.ToTable("Фабрика");

            entity.Property(e => e.ИдентификаторФабрики).HasColumnName("Идентификатор_фабрики");
            entity.Property(e => e.Адрес).HasMaxLength(500);
            entity.Property(e => e.ВместимостьСклада)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Вместимость_склада");
            entity.Property(e => e.ИдентификаторТипаФабрики).HasColumnName("Идентификатор_типа_фабрики");
            entity.Property(e => e.Название).HasMaxLength(200);

            entity.HasOne(d => d.ИдентификаторТипаФабрикиNavigation).WithMany(p => p.Фабрикаs)
                .HasForeignKey(d => d.ИдентификаторТипаФабрики)
                .HasConstraintName("FK__Фабрика__Идентиф__5AEE82B9");
        });

        modelBuilder.Entity<Ценообразование>(entity =>
        {
            entity.HasKey(e => e.ИдентификаторЦенообразования).HasName("PK__Ценообра__514781BB3B3BE296");

            entity.ToTable("Ценообразование");

            entity.Property(e => e.ИдентификаторЦенообразования).HasColumnName("Идентификатор_ценообразования");
            entity.Property(e => e.БазоваяЦена)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Базовая_цена");
            entity.Property(e => e.ДействительнаДо)
                .HasColumnType("datetime")
                .HasColumnName("Действительна_до");
            entity.Property(e => e.ДействительнаОт)
                .HasColumnType("datetime")
                .HasColumnName("Действительна_от");
            entity.Property(e => e.ИдентификаторНоменклатуры).HasColumnName("Идентификатор_номенклатуры");
            entity.Property(e => e.СкидкаДляЛояльных)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Скидка_для_лояльных");
            entity.Property(e => e.СкидкаДляПредпринимателей)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Скидка_для_предпринимателей");

            entity.HasOne(d => d.ИдентификаторНоменклатурыNavigation).WithMany(p => p.Ценообразованиеs)
                .HasForeignKey(d => d.ИдентификаторНоменклатуры)
                .HasConstraintName("FK__Ценообраз__Идент__00200768");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
