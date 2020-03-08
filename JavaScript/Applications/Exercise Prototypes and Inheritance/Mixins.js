function createMixins() {
    function computerQualityMixin(classToExtend) {
        function getQuality() {
            let result = (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
            return result;
        }

        function isFast() {
            if (this.processorSpeed > (this.ram / 4)) {
                return true;
            }
            return false;
        }

        function isRoomy() {
            if (this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed)) {
                return true;
            }
            return false;
        }

        classToExtend.prototype['getQuality'] = getQuality;;
        classToExtend.prototype['isFast'] = isFast;;
        classToExtend.prototype['isRoomy'] = isRoomy;;
    }

    function styleMixin(classToExtend) {
        function isFullSet() {
            if (this.manufacturer == this.keyboard.manufacturer && this.manufacturer == this.monitor.manufacturer) {
                return true;
            }
            return false;
        }

        function isClassy() {
            if (this.battery.expectedLife >= 3 &&
                (this.color == 'Silver' || this.color == 'Black') &&
                this.weight < 3) {
                return true;
            }
            return false;
        }

        classToExtend.prototype['isFullSet'] = isFullSet;
        classToExtend.prototype['isClassy'] = isClassy;
    }

    return {
        computerQualityMixin,
        styleMixin
    }
}
