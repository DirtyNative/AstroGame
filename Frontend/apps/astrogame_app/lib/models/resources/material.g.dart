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
    ..stellarObjectResources = (json['stellarObjectResources']
            as List<dynamic>?)
        ?.map((e) => StellarObjectResource.fromJson(e as Map<String, dynamic>))
        .toList()
    ..type = _$enumDecode(_$MaterialTypeEnumMap, json['type']);
}

Map<String, dynamic> _$MaterialToJson(Material instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'naturalOccurrenceWeight': instance.naturalOccurrenceWeight,
      'stellarObjectResources': instance.stellarObjectResources,
      'type': _$MaterialTypeEnumMap[instance.type],
    };

K _$enumDecode<K, V>(
  Map<K, V> enumValues,
  Object? source, {
  K? unknownValue,
}) {
  if (source == null) {
    throw ArgumentError(
      'A value must be provided. Supported values: '
      '${enumValues.values.join(', ')}',
    );
  }

  return enumValues.entries.singleWhere(
    (e) => e.value == source,
    orElse: () {
      if (unknownValue == null) {
        throw ArgumentError(
          '`$source` is not one of the supported values: '
          '${enumValues.values.join(', ')}',
        );
      }
      return MapEntry(unknownValue, enumValues.values.first);
    },
  ).key;
}

const _$MaterialTypeEnumMap = {
  MaterialType.building: 0,
  MaterialType.consumables: 1,
  MaterialType.components: 2,
  MaterialType.alloys: 3,
  MaterialType.fuels: 4,
};
