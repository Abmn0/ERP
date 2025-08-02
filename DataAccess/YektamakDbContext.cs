using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class YektamakDbContext : DbContext
    {
        public YektamakDbContext(DbContextOptions<YektamakDbContext> options)
            : base(options)
        {
        }

        // DbSet'ler
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<PersonelResim> PersonelResimler { get; set; }
        public DbSet<Pozisyon> Pozisyonlar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }

        // Yetkilendirme ve Menü Yönetimi
        public DbSet<MenuGroup> MenuGruplar { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Ekran> Ekranlar { get; set; }
        public DbSet<Alan> Alanlar { get; set; }
        public DbSet<Yetki> Yetkiler { get; set; }
        public DbSet<AlanYetki> AlanYetkiler { get; set; }


        // Stok Yönetimi
        public DbSet<StokKart> StokKartlar { get; set; }
        public DbSet<StokGrup> StokGruplar { get; set; }
        public DbSet<StokTip> StokTipler { get; set; }
        public DbSet<MalzemeGrup> MalzemeGruplar { get; set; }
        public DbSet<MalzemeAltGrup> MalzemeAltGruplar { get; set; }
        public DbSet<MalzemeAltGrup2> MalzemeAltGrup2ler { get; set; }
        public DbSet<OlcuBirim> OlcuBirimler { get; set; }
        public DbSet<MalzemeStandart> MalzemeStandartlar { get; set; }
        public DbSet<Hammadde> Hammaddeler { get; set; }

        // Proje Yönetimi
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<ProjeTip> ProjeTipler { get; set; }
        public DbSet<ProjeSorumlu> ProjeSorumlular { get; set; }
        public DbSet<ProjeStokKart> ProjeStokKartlar { get; set; }
        public DbSet<ProjeSurecTanim> ProjeSurecTanimlari { get; set; }
        public DbSet<ProjeTakvim> ProjeTakvimleri { get; set; }

        // Sipariş
        public DbSet<SatisSiparis> SatisSiparisler { get; set; }

        // Marka Yönetimi
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<MarkaAltGrup> MarkaAltGruplar { get; set; }
        public DbSet<MarkaAltGrupKategori> MarkaAltGrupKategoriler { get; set; }

        public DbSet<SatinalmaSiparisBaslik> SatinalmaSiparisBasliklar { get; set; }
        public DbSet<SatinalmaSiparisDetay> SatinalmaSiparisDetaylar { get; set; }
        public DbSet<SatinalmaTalepBaslik> SatinalmaTalepBasliklar { get; set; }
        public DbSet<SatinalmaTalepDetay> SatinalmaTalepDetaylar { get; set; }
        public DbSet<SatinalmaTeklifBaslik> SatinalmaTeklifBasliklar { get; set; }
        public DbSet<SatinalmaTeklifDetay> SatinalmaTeklifDetaylar { get; set; }
        public DbSet<Teklif> Teklifler { get; set; }
        public DbSet<TeklifMaliyetDetay> TeklifMaliyetDetaylar { get; set; }
        public DbSet<TeklifSurec> TeklifSurecler { get; set; }
        public DbSet<TeklifSurecTanim> TeklifSurecTanimlari { get; set; }
        public DbSet<TeklifTalep> TeklifTalepleri { get; set; }
        public DbSet<TeklifTalepBelge> TeklifTalepBelgeleri { get; set; }
        public DbSet<TeklifTalepSurec> TeklifTalepSurecler { get; set; }
        public DbSet<TeklifTalepSurecTanim> TeklifTalepSurecTanimlari { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kullanıcı ilişkileri
            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Rol)
                .WithMany()
                .HasForeignKey(k => k.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kullanici>()
                .HasOne(k => k.Personel)
                .WithMany()
                .HasForeignKey(k => k.PersonelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Personel ilişkileri
            modelBuilder.Entity<Personel>()
                .HasOne(p => p.Firma)
                .WithMany()
                .HasForeignKey(p => p.FirmaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Personel>()
                .HasOne(p => p.Pozisyon)
                .WithMany()
                .HasForeignKey(p => p.PozisyonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Personel>()
                .HasOne(p => p.PersonelResim)
                .WithMany()
                .HasForeignKey(p => p.PersonelResimId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Personel>()
                .HasOne(p => p.Yonetici)
                .WithMany(p => p.BagliPersoneller)
                .HasForeignKey(p => p.YoneticiPersonelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Firma ilişkileri
            modelBuilder.Entity<Firma>()
                .HasOne(f => f.Sehir)
                .WithMany()
                .HasForeignKey(f => f.SehirId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Firma>()
                .HasOne(f => f.Ulke)
                .WithMany()
                .HasForeignKey(f => f.UlkeId)
                .OnDelete(DeleteBehavior.Restrict);

            // PersonelResim ilişkisi
            modelBuilder.Entity<PersonelResim>()
                .HasOne(r => r.Personel)
                .WithMany()
                .HasForeignKey(r => r.PersonelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Pozisyon ayarları
            modelBuilder.Entity<Pozisyon>()
                .Property(p => p.Ad).HasMaxLength(45);

            modelBuilder.Entity<Pozisyon>()
                .Property(p => p.Kod).HasMaxLength(45);

            // Sehir - Ulke ilişkisi
            modelBuilder.Entity<Sehir>()
                .HasOne(s => s.Ulke)
                .WithMany()
                .HasForeignKey(s => s.UlkeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Menu - MenuGroup ilişkisi
            modelBuilder.Entity<Menu>()
                .HasOne<MenuGroup>()
                .WithMany()
                .HasForeignKey(m => m.MenuGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Alan - Menu ilişkisi
            modelBuilder.Entity<Alan>()
                .HasOne<Menu>()
                .WithMany()
                .HasForeignKey(a => a.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            // AlanYetki - Kullanici ve Alan
            modelBuilder.Entity<AlanYetki>()
                .HasOne<Kullanici>()
                .WithMany()
                .HasForeignKey(ay => ay.KullaniciId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AlanYetki>()
                .HasOne<Alan>()
                .WithMany()
                .HasForeignKey(ay => ay.AlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // Yetki - Rol, Menu, Ekran, Alan
            modelBuilder.Entity<Yetki>()
                .HasOne(y => y.Rol)
                .WithMany()
                .HasForeignKey(y => y.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Yetki>()
                .HasOne(y => y.Menu)
                .WithMany()
                .HasForeignKey(y => y.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Yetki>()
                .HasOne(y => y.Ekran)
                .WithMany()
                .HasForeignKey(y => y.EkranId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Yetki>()
                .HasOne(y => y.Alan)
                .WithMany()
                .HasForeignKey(y => y.AlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // StokKart ilişkileri
            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.StokGrup)
                .WithMany(g => g.StokKartlar)
                .HasForeignKey(sk => sk.StokGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.StokTip)
                .WithMany(t => t.StokKartlar)
                .HasForeignKey(sk => sk.StokTipId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.MalzemeGrup)
                .WithMany(g => g.StokKartlar)
                .HasForeignKey(sk => sk.MalzemeGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.MalzemeAltGrup)
                .WithMany(g => g.StokKartlar)
                .HasForeignKey(sk => sk.MalzemeAltGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.MalzemeAltGrup2)
                .WithMany(g => g.StokKartlar)
                .HasForeignKey(sk => sk.MalzemeAltGrup2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.OlcuBirim)
                .WithMany(b => b.StokKartlar)
                .HasForeignKey(sk => sk.OlcuBirimId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.MalzemeStandart)
                .WithMany(ms => ms.StokKartlar)
                .HasForeignKey(sk => sk.MalzemeStandartId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StokKart>()
                .HasOne(sk => sk.Hammadde)
                .WithMany(h => h.StokKartlar)
                .HasForeignKey(sk => sk.HammaddeId)
                .OnDelete(DeleteBehavior.Restrict);

            // MalzemeGrup - StokGrup
            modelBuilder.Entity<MalzemeGrup>()
                .HasOne(mg => mg.StokGrup)
                .WithMany(g => g.MalzemeGruplar)
                .HasForeignKey(mg => mg.StokGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            // MalzemeAltGrup - MalzemeGrup
            modelBuilder.Entity<MalzemeAltGrup>()
                .HasOne(mag => mag.MalzemeGrup)
                .WithMany(g => g.MalzemeAltGruplar)
                .HasForeignKey(mag => mag.MalzemeGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            // MalzemeAltGrup2 - MalzemeAltGrup
            modelBuilder.Entity<MalzemeAltGrup2>()
                .HasOne(mag2 => mag2.MalzemeAltGrup)
                .WithMany(g => g.MalzemeAltGrup2ler)
                .HasForeignKey(mag2 => mag2.MalzemeAltGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Marka - MarkaAltGrup
            modelBuilder.Entity<MarkaAltGrup>()
                .HasOne(m => m.Marka)
                .WithMany(ma => ma.MarkaAltGruplar)
                .HasForeignKey(m => m.MarkaId)
                .OnDelete(DeleteBehavior.Restrict);

            // MarkaAltGrup - MarkaAltGrupKategori
            modelBuilder.Entity<MarkaAltGrupKategori>()
                .HasOne(k => k.MarkaAltGrup)
                .WithMany(m => m.MarkaAltGrupKategoriler)
                .HasForeignKey(k => k.MarkaAltGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Proje - ProjeTip
            modelBuilder.Entity<Proje>()
                .HasOne(p => p.ProjeTip)
                .WithMany(pt => pt.Projeler)
                .HasForeignKey(p => p.ProjeTipId)
                .OnDelete(DeleteBehavior.Restrict);

            // Proje - Marka
            modelBuilder.Entity<Proje>()
                .HasOne(p => p.Marka)
                .WithMany()
                .HasForeignKey(p => p.MarkaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Proje - AltGrup
            modelBuilder.Entity<Proje>()
                .HasOne(p => p.AltGrup)
                .WithMany()
                .HasForeignKey(p => p.AltGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Proje - Kategori
            modelBuilder.Entity<Proje>()
                .HasOne(p => p.Kategori)
                .WithMany()
                .HasForeignKey(p => p.KategoriId)
                .OnDelete(DeleteBehavior.Restrict);

            // Proje - SatisSiparis
            modelBuilder.Entity<Proje>()
                .HasOne(p => p.SatisSiparis)
                .WithMany()
                .HasForeignKey(p => p.SatisSiparisId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProjeSorumlu
            modelBuilder.Entity<ProjeSorumlu>()
                .HasOne(ps => ps.Proje)
                .WithMany()
                .HasForeignKey(ps => ps.ProjeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjeSorumlu>()
                .HasOne(ps => ps.Personel)
                .WithMany()
                .HasForeignKey(ps => ps.PersonelId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProjeStokKart
            modelBuilder.Entity<ProjeStokKart>()
                .HasOne(p => p.Proje)
                .WithMany()
                .HasForeignKey(p => p.ProjeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjeStokKart>()
                .HasOne(p => p.StokKart)
                .WithMany()
                .HasForeignKey(p => p.StokKartId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProjeTakvim
            modelBuilder.Entity<ProjeTakvim>()
                .HasOne(p => p.Proje)
                .WithMany()
                .HasForeignKey(p => p.ProjeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjeTakvim>()
                .HasOne(p => p.ProjeSurec)
                .WithMany()
                .HasForeignKey(p => p.ProjeSurecId)
                .OnDelete(DeleteBehavior.Restrict);

            // Satınalma Sipariş Detayları
            modelBuilder.Entity<SatinalmaSiparisDetay>()
                .HasOne(d => d.Baslik)
                .WithMany(b => b.Detaylar)
                .HasForeignKey(d => d.SatinalmaSiparisBaslikId);

            // Satınalma Talep Detayları
            modelBuilder.Entity<SatinalmaTalepDetay>()
                .HasOne(d => d.Baslik)
                .WithMany(b => b.Detaylar)
                .HasForeignKey(d => d.SatinalmaTalepBaslikId);

            // Satınalma Teklif Detayları
            modelBuilder.Entity<SatinalmaTeklifDetay>()
                .HasOne(d => d.Baslik)
                .WithMany(b => b.Detaylar)
                .HasForeignKey(d => d.SatinalmaTeklifBaslikId);

            // TeklifMaliyetDetay -> Teklif
            modelBuilder.Entity<TeklifMaliyetDetay>()
                .HasOne(d => d.Teklif)
                .WithMany(t => t.MaliyetDetaylari)
                .HasForeignKey(d => d.TeklifId);

            // TeklifSurec -> Teklif
            modelBuilder.Entity<TeklifSurec>()
                .HasOne(s => s.Teklif)
                .WithMany(t => t.Surecler)
                .HasForeignKey(s => s.TeklifId);

            // TeklifSurec -> SurecTanim
            modelBuilder.Entity<TeklifSurec>()
                .HasOne(s => s.SurecTanim)
                .WithMany(t => t.Surecler)
                .HasForeignKey(s => s.TeklifSurecTanimId);

            // TeklifTalepBelge -> TeklifTalep
            modelBuilder.Entity<TeklifTalepBelge>()
                .HasOne(b => b.TeklifTalep)
                .WithMany(t => t.Belgeler)
                .HasForeignKey(b => b.TeklifTalepId);

            // TeklifTalepSurec -> TeklifTalep
            modelBuilder.Entity<TeklifTalepSurec>()
                .HasOne(s => s.TeklifTalep)
                .WithMany(t => t.Surecler)
                .HasForeignKey(s => s.TeklifTalepId);

            // TeklifTalepSurec -> SurecTanim
            modelBuilder.Entity<TeklifTalepSurec>()
                .HasOne(s => s.SurecTanim)
                .WithMany(t => t.Surecler)
                .HasForeignKey(s => s.TeklifTalepSurecTanimId);

            // Eksik olan: SatinalmaTeklifDetay -> SatinalmaTalepDetay
            modelBuilder.Entity<SatinalmaTeklifDetay>()
                .HasOne<SatinalmaTalepDetay>()
                .WithMany()
                .HasForeignKey(d => d.SatinalmaTalepDetayId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: Teklif -> Firma
            modelBuilder.Entity<Teklif>()
                .HasOne<Firma>()
                .WithMany()
                .HasForeignKey(t => t.FirmaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: Teklif -> Personel (SatisSorumluId)
            modelBuilder.Entity<Teklif>()
                .HasOne<Personel>()
                .WithMany()
                .HasForeignKey(t => t.SatisSorumluId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: TeklifTalep -> Firma
            modelBuilder.Entity<TeklifTalep>()
                .HasOne<Firma>()
                .WithMany()
                .HasForeignKey(t => t.FirmaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: TeklifTalep -> Personel (SatisSorumlusuId)
            modelBuilder.Entity<TeklifTalep>()
                .HasOne<Personel>()
                .WithMany()
                .HasForeignKey(t => t.SatisSorumlusuId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: TeklifTalep -> Marka
            modelBuilder.Entity<TeklifTalep>()
                .HasOne<Marka>()
                .WithMany()
                .HasForeignKey(t => t.MarkaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: TeklifTalep -> MarkaAltGrup
            modelBuilder.Entity<TeklifTalep>()
                .HasOne<MarkaAltGrup>()
                .WithMany()
                .HasForeignKey(t => t.AltGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: TeklifTalep -> MarkaAltGrupKategori
            modelBuilder.Entity<TeklifTalep>()
                .HasOne<MarkaAltGrupKategori>()
                .WithMany()
                .HasForeignKey(t => t.KategoriId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: TeklifTalep -> ProjeTakvim (FinansalTakvimId)
            modelBuilder.Entity<TeklifTalep>()
                .HasOne<ProjeTakvim>()
                .WithMany()
                .HasForeignKey(t => t.FinansalTakvimId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: SatinalmaTalepDetay -> StokKart
            modelBuilder.Entity<SatinalmaTalepDetay>()
                .HasOne<StokKart>()
                .WithMany()
                .HasForeignKey(t => t.StokKartId)
                .OnDelete(DeleteBehavior.Restrict);

            // Eksik olan: SatinalmaTalepDetay -> OlcuBirim
            modelBuilder.Entity<SatinalmaTalepDetay>()
                .HasOne<OlcuBirim>()
                .WithMany()
                .HasForeignKey(t => t.OlcuBirimi)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SatinalmaTalepBaslik>()
     .HasOne(b => b.Firma)              // navigation property
     .WithMany()                        // Firma tarafında koleksiyon yoksa boş bırakılır
     .HasForeignKey(b => b.FirmaId);



            // Tablo adları
            modelBuilder.Entity<Kullanici>().ToTable("kullanici");
            modelBuilder.Entity<Personel>().ToTable("personel");
            modelBuilder.Entity<Firma>().ToTable("firma");
            modelBuilder.Entity<PersonelResim>().ToTable("personelresim");
            modelBuilder.Entity<Pozisyon>().ToTable("pozisyon");
            modelBuilder.Entity<Rol>().ToTable("rol");
            modelBuilder.Entity<Sehir>().ToTable("sehir");
            modelBuilder.Entity<Ulke>().ToTable("ulke");

            modelBuilder.Entity<MenuGroup>().ToTable("menugroup");
            modelBuilder.Entity<Menu>().ToTable("menu");
            modelBuilder.Entity<Ekran>().ToTable("ekran");
            modelBuilder.Entity<Alan>().ToTable("alan");
            modelBuilder.Entity<Yetki>().ToTable("yetki");
            modelBuilder.Entity<AlanYetki>().ToTable("alanyetki");

            modelBuilder.Entity<StokKart>().ToTable("stokkart");
            modelBuilder.Entity<StokGrup>().ToTable("stokgrup");
            modelBuilder.Entity<StokTip>().ToTable("stoktip");
            modelBuilder.Entity<MalzemeGrup>().ToTable("malzemegrup");
            modelBuilder.Entity<MalzemeAltGrup>().ToTable("malzemealtgrup");
            modelBuilder.Entity<MalzemeAltGrup2>().ToTable("malzemealtgrup2");
            modelBuilder.Entity<OlcuBirim>().ToTable("olcubirim");
            modelBuilder.Entity<MalzemeStandart>().ToTable("malzemestandart");
            modelBuilder.Entity<Hammadde>().ToTable("hammadde");

            modelBuilder.Entity<Proje>().ToTable("proje");
            modelBuilder.Entity<ProjeTip>().ToTable("projetip");
            modelBuilder.Entity<Marka>().ToTable("marka");
            modelBuilder.Entity<MarkaAltGrup>().ToTable("markaaltgrup");
            modelBuilder.Entity<MarkaAltGrupKategori>().ToTable("markaaltgrupkategori");
            modelBuilder.Entity<SatisSiparis>().ToTable("satissiparis");
            
            modelBuilder.Entity<ProjeSorumlu>().ToTable("projesorumlu");
            modelBuilder.Entity<ProjeStokKart>().ToTable("projestokkart");
            modelBuilder.Entity<ProjeSurecTanim>().ToTable("projesurectanim");
            modelBuilder.Entity<ProjeTakvim>().ToTable("projetakvim");

            modelBuilder.Entity<SatinalmaSiparisBaslik>().ToTable("satinalmasiparisbaslik");
            modelBuilder.Entity<SatinalmaSiparisDetay>().ToTable("satinalmasiparisdetay");
            modelBuilder.Entity<SatinalmaTalepBaslik>().ToTable("satinalmatalepbaslik");
            modelBuilder.Entity<SatinalmaTalepDetay>().ToTable("satinalmatalepdetay");
            modelBuilder.Entity<SatinalmaTeklifBaslik>().ToTable("satinalmateklifbaslik");
            modelBuilder.Entity<SatinalmaTeklifDetay>().ToTable("satinalmateklifdetay");
            modelBuilder.Entity<Teklif>().ToTable("teklif");
            modelBuilder.Entity<TeklifMaliyetDetay>().ToTable("teklifmaliyetdetay");
            modelBuilder.Entity<TeklifSurec>().ToTable("teklifsurec");
            modelBuilder.Entity<TeklifSurecTanim>().ToTable("teklifsurectanim");
            modelBuilder.Entity<TeklifTalep>().ToTable("tekliftalep");
            modelBuilder.Entity<TeklifTalepBelge>().ToTable("tekliftalepbelge");
            modelBuilder.Entity<TeklifTalepSurec>().ToTable("tekliftalepsurec");
            modelBuilder.Entity<TeklifTalepSurecTanim>().ToTable("tekliftalepsurectanim");


            base.OnModelCreating(modelBuilder);
        }
    }
}
