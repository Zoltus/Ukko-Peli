namespace Autopeli {
    public interface Slowable {
        bool IsSlowed { get; set; }
        public void slowDown();
        public void speedUp();
    }
}