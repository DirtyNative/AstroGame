// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'species.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Species _$SpeciesFromJson(Map<String, dynamic> json) {
  return Species()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..speciesType =
        _$enumDecodeNullable(_$SpeciesTypeEnumMap, json['speciesType'])
    ..assetName = json['assetName'] as String;
}

Map<String, dynamic> _$SpeciesToJson(Species instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'speciesType': _$SpeciesTypeEnumMap[instance.speciesType],
      'assetName': instance.assetName,
    };

T _$enumDecode<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    throw ArgumentError('A value must be provided. Supported values: '
        '${enumValues.values.join(', ')}');
  }

  final value = enumValues.entries
      .singleWhere((e) => e.value == source, orElse: () => null)
      ?.key;

  if (value == null && unknownValue == null) {
    throw ArgumentError('`$source` is not one of the supported values: '
        '${enumValues.values.join(', ')}');
  }
  return value ?? unknownValue;
}

T _$enumDecodeNullable<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    return null;
  }
  return _$enumDecode<T>(enumValues, source, unknownValue: unknownValue);
}

const _$SpeciesTypeEnumMap = {
  SpeciesType.lithoid: 0,
  SpeciesType.humanoid: 1,
  SpeciesType.arthropoid: 2,
  SpeciesType.swarm: 3,
  SpeciesType.avian: 4,
  SpeciesType.mammalian: 5,
  SpeciesType.molluscoid: 6,
  SpeciesType.necroid: 7,
  SpeciesType.plantoid: 8,
  SpeciesType.reptilian: 9,
  SpeciesType.synthetic: 10,
  SpeciesType.fungoid: 11,
};
