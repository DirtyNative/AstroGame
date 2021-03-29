// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'material.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Material _$MaterialFromJson(Map<String, dynamic> json) {
  return Material()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..naturalOccurrenceWeight = json['naturalOccurrenceWeight'] as int
    ..stellarObjectResources = (json['stellarObjectResources'] as List)
        ?.map((e) => e == null
            ? null
            : StellarObjectResource.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..type = _$enumDecodeNullable(_$MaterialTypeEnumMap, json['type']);
}

Map<String, dynamic> _$MaterialToJson(Material instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'naturalOccurrenceWeight': instance.naturalOccurrenceWeight,
      'stellarObjectResources': instance.stellarObjectResources,
      'type': _$MaterialTypeEnumMap[instance.type],
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

const _$MaterialTypeEnumMap = {
  MaterialType.building: 'building',
  MaterialType.consumables: 'consumables',
  MaterialType.components: 'components',
  MaterialType.alloys: 'alloys',
  MaterialType.fuels: 'fuels',
};
